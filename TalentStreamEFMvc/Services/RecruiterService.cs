using TalentStreamEFMvc.Models;

namespace TalentStreamEFMvc.Services
{
    public class RecruiterService
    {
        private readonly TalentStreamDbContext _dbContext;

        public RecruiterService(TalentStreamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterRecruiter(Recruiter recruiter)
        {
            _dbContext.Recruiters.Add(recruiter);
            _dbContext.SaveChanges();
        }

        public Recruiter RecruiterById(int id)
        {
            return _dbContext.Recruiters.First(c => c.RecruiterId == id);
        }

        public void RecruiterUpdate(Recruiter recruiter)
        {
            _dbContext.Recruiters.Update(recruiter);
            _dbContext.SaveChanges();

        }
        public List<Recruiter> RecruitersList()
        {
            return _dbContext.Recruiters.ToList();
        }
    }
}
