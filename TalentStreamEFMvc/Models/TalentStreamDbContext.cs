using Microsoft.EntityFrameworkCore;
using TalentStreamEFMvc.Exceptions;

namespace TalentStreamEFMvc.Models
{
    public class TalentStreamDbContext : DbContext
    {
        public TalentStreamDbContext(DbContextOptions<TalentStreamDbContext> options) : base(options) 
        { 
        }

        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                // Configure the relationship
                modelBuilder.Entity<Job>()
                    .HasOne(j => j.Recruiter)
                    .WithMany(r => r.Jobs)
                    .HasForeignKey(j => j.RecruiterId)
                    .OnDelete(DeleteBehavior.Cascade); 
            }
            catch (Exception ex)
            {
                
                throw new ModelConfigurationException("Error during model configuration", ex);
            }
        }

    }
}
