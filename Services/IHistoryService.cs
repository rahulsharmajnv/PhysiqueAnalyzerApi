using System.Collections.Generic;
using PhysiqueAnalyzerApi.Models;

namespace PhysiqueAnalyzerApi.Services
{
    public interface IHistoryService
    {
        List<WorkoutHistory> GetHistoryForUser(int userId);
        WorkoutHistory AddHistoryForUser(int userId, string date, string workout, string recommendation, string fileAnalyzed);
    }
}