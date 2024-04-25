using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class AddEmployeeForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int civilId { get; set; }
        [Required]
        public string position { get; set; }
    }
}
