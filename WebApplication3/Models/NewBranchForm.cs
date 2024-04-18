using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class NewBranchForm
    {
        [Required(ErrorMessage ="Branch name is required!!")]
        [Display(Name = "Branch Name")]
        public string branchName { get; set; }



        [Required(ErrorMessage = "Branch location is required!!")]
        [Display(Name = "Branch location")]
        public string location { get; set; }



        [Required(ErrorMessage = "Branch location URL is required!!")]
        [Url(ErrorMessage = "INVALID URL")]
        [Display(Name = "location URL")]
        public string locationURL { get; set; }



        [Display(Name = "Branch Manager Name")]
        [Required(ErrorMessage = "Branch manager is required!!")]
        public string branchMnager { get; set; }



        [Display(Name = "Branch Employee Count")]
        [Required(ErrorMessage = "Branch employee count is required!!")]
        [Range(1 , int.MaxValue, ErrorMessage = "Employee count must be 1 or more")]
        public int employeeCount { get; set; }
    }
}
