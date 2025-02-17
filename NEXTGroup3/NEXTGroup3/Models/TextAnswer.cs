namespace NEXTGroup3.Models
{
    public class TextAnswer
    {
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
