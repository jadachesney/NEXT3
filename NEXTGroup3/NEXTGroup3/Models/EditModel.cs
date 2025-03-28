using System.ComponentModel.DataAnnotations;

namespace NEXTGroup3.Models
{
  public class EditModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

  }
}
