namespace NEXTGroup3.Models
{
    public class TextAnswer
    {
        //ID
        private int id;
        public int Id { get { return id; } set { id = value; } }

        //ANSWERS 
        private List<string> answers;
        public List<string> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        //ROLE
        private Role role;
        public Role Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
