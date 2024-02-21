using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentStreamEFMvc.Models
{
    public class Recruiter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecruiterId { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Mobile Number")]
        public string? MobileNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        // Navigation property
        public virtual List<Job>? Jobs { get; set; }
    }
}
