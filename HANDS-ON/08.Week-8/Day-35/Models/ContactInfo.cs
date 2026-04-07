using System.ComponentModel.DataAnnotations;

public class ContactInfo
{
    public int ContactId { get; set; }

    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? EmailId { get; set; }

    [Required]
    [Phone]
    public long MobileNo { get; set; }

    [Required]
    public string? Designation { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    public string? CompanyName { get; set; }

    public string? DepartmentName { get; set; }
}