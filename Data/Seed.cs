using System.Collections.Generic;
using SM.API.Models;
using Newtonsoft.Json;

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

            var teamsData = System.IO.File.ReadAllText("Data/SeedData/Teams.json");
            var teams = JsonConvert.DeserializeObject<List<Team>>(teamsData);
            _context.Teams.AddRange(teams);

            _context.SaveChanges();
        }
    }
}