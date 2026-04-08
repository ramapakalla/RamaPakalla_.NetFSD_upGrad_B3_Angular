using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class Company
    {
        public int CompanyId { get; set; }


        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
    }
}
