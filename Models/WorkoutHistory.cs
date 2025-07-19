namespace PhysiqueAnalyzerApi.Models
{
    public class WorkoutHistory
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Workout { get; set; }
        public string Recommendation { get; set; }
        public string FileAnalyzed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}