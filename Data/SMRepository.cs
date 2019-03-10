using System.Collections.Generic;
using System.Threading.Tasks;
using SM.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SM.API.DTOs;

namespace SM.API.Data
{
    public class SMRepository : ISMRepository
    {
        private readonly DataContext _context;
        public SMRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Matchday>> GetMatchdaysAsync()
        {
            return await _context.Matchdays
                .Include(md => md.Season).ThenInclude(s => s.League)
                .Include(md => md.Matches).ThenInclude(m => m.HomeTeam)
                .Include(md => md.Matches).ThenInclude(m => m.AwayTeam)
                .Include(md => md.Matches).ThenInclude(m => m.Predictions).ThenInclude(p => p.User)
                .OrderByDescending(md => md.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<LeaderboardsDto>> GetLeaderboardsAsync()
        {
            var result = new List<LeaderboardsDto>();

            var leagues = await _context.Leagues
                .Include(l => l.Seasons).ThenInclude(s => s.Matchdays).ThenInclude(md => md.Matches).ThenInclude(m => m.Predictions).ThenInclude(p => p.User)
                .ToListAsync();

            foreach (var league in leagues)
            {
                foreach (var season in league.Seasons)
                {
                    var leaderboardDto = new LeaderboardsDto { Title = $"{league.Title} {season.Title}" };

                    var seasonMatchIds = season.Matchdays.SelectMany(md => md.Matches).Select(m => m.Id);
                    var predictions = await _context.Predictions.Where(p => seasonMatchIds.Contains(p.MatchId)).ToListAsync();
                    var orderedGroupedPredictions = predictions.GroupBy(p => p.User.Username);

                    var ranks = new List<RankDto>();
                    foreach (var orderedGroupedPrediction in orderedGroupedPredictions)
                    {
                        var rank = new RankDto
                        {
                            User = orderedGroupedPrediction.Key,
                            TotalPoint = orderedGroupedPrediction.Sum(grp => grp.Point.GetValueOrDefault()),
                            TotalGame = orderedGroupedPrediction.Count(grp => grp.Point != null),
                            TotalCorrectScore = orderedGroupedPrediction.Count(grp => grp.Point == 3),
                            TotalCorrectResult = orderedGroupedPrediction.Count(grp => grp.Point == 1),
                            TotalWrong = orderedGroupedPrediction.Count(grp => grp.Point == 0)
                        };

                        ranks.Add(rank);
                    }

                    leaderboardDto.Ranks = ranks
                        .OrderByDescending(r => r.TotalPoint)
                        .ThenByDescending(r => r.WinningRate)
                        .ThenByDescending(r => r.TotalCorrectScore)
                        .ThenByDescending(r => r.TotalCorrectResult)
                        .ThenBy(r => r.TotalGame)
                        .ThenBy(r => r.User);

                    var idx = 0;
                    leaderboardDto.Ranks.ToList().ForEach(r => r.Sequence = ++idx);

                    result.Add(leaderboardDto);
                }
            }

            return result;
        }
    }
}