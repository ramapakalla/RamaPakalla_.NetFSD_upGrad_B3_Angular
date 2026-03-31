using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
  
public class ContactInfo
{
    [Required]
    public int ContactId { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string CompanyName { get; set; }

    [EmailAddress]
    public string EmailId { get; set; }

    [Required]
    [Range(6000000000, 9999999999, ErrorMessage = "Enter valid mobile number")]
        public long MobileNo { get; set; }

    [Required]
    public string Designation { get; set; }
}
}
