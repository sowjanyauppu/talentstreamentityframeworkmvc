using Microsoft.EntityFrameworkCore;

namespace TalentStreamEFMvc.Models
{
    public class ApplicantDbContext : DbContext
    {
        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        public override int SaveChanges()
        {
            UpdateApplicantIds();
            return base.SaveChanges();
        }

        private void UpdateApplicantIds()
        {
            //iterates through all the entities in the ChangeTracker that are in the Added state. 
            //keeps track of changes made to entities, and this line filters only the entities that are being added (not modified or deleted).

            foreach (var entry in ChangeTracker.Entries<Applicant>().Where(e => e.State == EntityState.Added))
            {
                var applicant = entry.Entity;

                // Check if the applicantId is already set
                if (string.IsNullOrEmpty(applicant.ApplicantId))
                {
                    // Generate the next applicantId
                    applicant.ApplicantId = GenerateNextApplicantId();
                }
            }
        }

        private string GenerateNextApplicantId()
        {
            // Retrieve the latest applicantId from the database
            var latestApplicant = Applicants.OrderByDescending(a => a.ApplicantId).FirstOrDefault();

            // If no records exist, start with "tlntsrm001"
            if (latestApplicant == null)
            {
                return "tlntsrm001";
            }

            // Extract the numeric part of the latest applicantId
            var numericPart = latestApplicant.ApplicantId.Substring(8);

            // Increment the numeric part and format it back
            var nextNumericPart = (int.Parse(numericPart) + 1).ToString("D3");

            // Form the next applicantId
            return "tlntsrm" + nextNumericPart;
        }
    }
}
