using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Range(6000000000, 9999999999, ErrorMessage = "Invalid mobile number")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "CompanyId is required")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }
    }
}