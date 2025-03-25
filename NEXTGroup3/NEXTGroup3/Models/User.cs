using System.Data;
using System.ComponentModel.DataAnnotations;

namespace NEXTGroup3.Models
{
    public class User
    {
        // USER ID
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        // USER EMAIL
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // USER PASSWORD
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
