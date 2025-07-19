using Microsoft.EntityFrameworkCore;
using PhysiqueAnalyzerApi.Models;

namespace PhysiqueAnalyzerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutHistory> WorkoutHistories { get; set; }
    }
}