namespace NEXTGroup3.Models
{
    public class TextAnswer
    {
        //ID
        private int id;
        public int Id { get { return id; } set { id = value; } }

        //ANSWERS 
        private string answers;
        public string Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        //ROLE
        private int roleId;
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
    }
}
