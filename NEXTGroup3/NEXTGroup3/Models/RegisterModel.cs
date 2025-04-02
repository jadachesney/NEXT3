using System.ComponentModel.DataAnnotations;

namespace NEXTGroup3.Models
{
  public class RegisterModel
  {
    // REGISTER MODEL, ALL REQUIRED INFORMATION FOR REGISTERING A NEW USER 
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    public string FirstName { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    // OPTIONAL
    public string StaffId { get; set; } = "";
  }
}
