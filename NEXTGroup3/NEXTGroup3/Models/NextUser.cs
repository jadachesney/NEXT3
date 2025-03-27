using Microsoft.AspNetCore.Identity;

namespace NEXTGroup3.Models
{
  public class NextUser : IdentityUser
  {
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
  }
}
