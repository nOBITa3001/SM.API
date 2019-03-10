using System.Collections.Generic;
using SM.API.Models;
using Newtonsoft.Json;
using SM.API.DTOs;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;

namespace SM.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedTeams()
        {
            _context.Teams.RemoveRange(_context.Teams);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Teams.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<Team>>(data);
            _context.Teams.AddRange(entities);

            _context.SaveChanges();
        }

        public void SeedLeagues()
        {
            _context.Leagues.RemoveRange(_context.Leagues);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Leagues.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<League>>(data);
            _context.Leagues.AddRange(entities);

            _context.SaveChanges();
        }

        public void SeedSeasons()
        {
            _context.Seasons.RemoveRange(_context.Seasons);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Seasons.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<Season>>(data);
            _context.Seasons.AddRange(entities);

            _context.SaveChanges();
        }

        public void SeedMatchdays()
        {
            _context.Matchdays.RemoveRange(_context.Matchdays);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Matchdays.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<Matchday>>(data);
            _context.Matchdays.AddRange(entities);

            _context.SaveChanges();
        }

        public void SeedMatches()
        {
            _context.Matches.RemoveRange(_context.Matches);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Matches.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<Match>>(data);
            _context.Matches.AddRange(entities);

            _context.SaveChanges();
        }

        public void SeedUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();

            var userData = File.ReadAllText("Data/SeedData/Users.json");
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(userData);
            foreach (var user in users)
            {
                CreatePasswordHash("password", out var passwordHash, out var passwordSalt);
                
                user.Username = user.Username.ToLower();
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Created = DateTime.UtcNow;
                user.Edited = DateTime.UtcNow;
                user.LastActive = DateTime.UtcNow;

                _context.Users.Add(user);
            }

             _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public void SeedPredictions()
        {
            _context.Predictions.RemoveRange(_context.Predictions);
            _context.SaveChanges();

            var data = File.ReadAllText("Data/SeedData/Predictions.json");
            var entities = JsonConvert.DeserializeObject<IEnumerable<Prediction>>(data);

            CalculatePredictionPoints(entities);

            _context.Predictions.AddRange(entities);

            _context.SaveChanges();
        }

        private void CalculatePredictionPoints(IEnumerable<Prediction> preditions)
        {
            var matchData = File.ReadAllText("Data/SeedData/Matches.json");
            var matches = JsonConvert.DeserializeObject<IEnumerable<Match>>(matchData);

            foreach (var predict in preditions.Where(entity => entity.Point == null))
            {
                var matchResult = matches.FirstOrDefault(match => match.Id == predict.MatchId)?.Result;
                if (string.IsNullOrWhiteSpace(matchResult))
                    continue;

                if (matchResult == predict.Result)
                    predict.Point = 3;
                else
                {
                    var foo = matchResult.Split('-').Select(x => int.Parse(x)).ToArray();
                    var bar = predict.Result.Split('-').Select(x => int.Parse(x)).ToArray();

                    // if (foo[0] > foo[1] && bar[0] > bar[1]
                    //     || foo[0] == foo[1] && bar[0] == bar[1]
                    //     || foo[0] < foo[1] && bar[0] < bar[1])
                    // {
                    //     predict.Point = 1;
                    // }
                    // else
                    // {
                    //     predict.Point = 0;
                    // }

                    predict.Point = (foo[0] > foo[1] && bar[0] > bar[1]
                                        || foo[0] == foo[1] && bar[0] == bar[1]
                                        || foo[0] < foo[1] && bar[0] < bar[1]
                                    ? 1
                                    : 0);
                }
            }
        }
    }
}
