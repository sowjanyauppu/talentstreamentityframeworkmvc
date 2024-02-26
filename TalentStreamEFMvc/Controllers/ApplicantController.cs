using Microsoft.AspNetCore.Mvc;
using TalentStreamEFMvc.Models;

namespace TalentStreamEFMvc.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ApplicantDbContext _applicantDbContext;

        public ApplicantController(ApplicantDbContext applicantDbContext)
        {
            _applicantDbContext = applicantDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Register(Applicant applicant)
        {
            try
            {
               
                _applicantDbContext.Applicants.Add(applicant);
                _applicantDbContext.SaveChanges();

                return Ok(new { Message = "Applicant registered successfully", ApplicantId = applicant.ApplicantId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error registering applicant", Error = ex.Message });
            }
        }

    }
}
