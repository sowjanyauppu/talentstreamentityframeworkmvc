using Microsoft.AspNetCore.Mvc;
using TalentStreamEFMvc.Models;
using TalentStreamEFMvc.Services;

namespace TalentStreamEFMvc.Controllers
{
    public class RecruiterController : Controller
    {
        private readonly RecruiterService _recruiterService;

        public RecruiterController(RecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _recruiterService.RegisterRecruiter(recruiter);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Error occurred during registration. Please try again.");
                }
            }
            return View(recruiter);
        }

        public IActionResult Update(int id)
        {
            return View(_recruiterService.RecruiterById(id));
        }

        [HttpPost]
        public IActionResult Update(Recruiter recruiter)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _recruiterService.RecruiterUpdate(recruiter);
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, "Error occurred during update. Please try again.");
                }
            }
            return View(recruiter);

        }
        public IActionResult List()
        {
            return View(_recruiterService.RecruitersList());
        }
    }
}
