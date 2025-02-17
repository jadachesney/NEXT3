namespace NEXTGroup3.Models
{
    public class TextQuestion : Question
    {
        //ANSWERS
        private List<TextAnswer> answers;
        public List<TextAnswer> Answers
        {
            get { return answers; }
            set { answers = value; }
        }
    }
}
