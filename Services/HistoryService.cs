using System.Collections.Generic;
using System.Linq;
using PhysiqueAnalyzerApi.Models;
using PhysiqueAnalyzerApi.Data;

namespace PhysiqueAnalyzerApi.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext _context;
        public HistoryService(ApplicationDbContext context) { _context = context; }
        public List<WorkoutHistory> GetHistoryForUser(int userId)
        {
            return _context.WorkoutHistories.Where(h => h.UserId == userId).OrderByDescending(h => h.Id).ToList();
        }
        public WorkoutHistory AddHistoryForUser(int userId, string date, string workout, string recommendation, string fileAnalyzed)
        {
            var history = new WorkoutHistory
            {
                Date = date,
                Workout = workout,
                Recommendation = recommendation,
                FileAnalyzed = fileAnalyzed,
                UserId = userId
            };
            _context.WorkoutHistories.Add(history);
            _context.SaveChanges();
            return history;
        }
    }
}