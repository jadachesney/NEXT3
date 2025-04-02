using System.ComponentModel.DataAnnotations;

namespace NEXTGroup3.Models
{
    public class EditModel
    {
        // MODEL FOR EDITING USER INFORMATION AND UPDATING THE STORED INFORMATION
        [EmailAddress]
        public string Email { get; set; } = "";

        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = "";

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

    }
}
