using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TalentStreamEFMvc.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "Minimum Experience is required")]
        public int MinExperience { get; set; }

        [Required(ErrorMessage = "Maximum Experience is required")]
        public int MaxExperience { get; set; }

        [Required(ErrorMessage = "Minimum Salary is required")]
        public double MinSalary { get; set; }

        [Required(ErrorMessage = "Maximum Salary is required")]
        public double MaxSalary { get; set; }

        [Required(ErrorMessage = "Skills are required")]
        public List<string>? RequiredSkills { get; set; }

        // Foreign key
        [ForeignKey("RecruiterId")]
        public int RecruiterId { get; set; }

        // Navigation property
        public virtual Recruiter Recruiter { get; set; }
    }
}
