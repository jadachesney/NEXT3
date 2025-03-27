using System.ComponentModel.DataAnnotations;

namespace NEXTGroup3.Models
{
  public class LoginModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    public string StaffId { get; set; } = "";

  }
}
