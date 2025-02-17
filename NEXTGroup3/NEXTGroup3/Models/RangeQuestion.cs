namespace NEXTGroup3.Models
{
    public class RangeQuestion : Question
    {

        // LEFT DEPARTMENTS LIST
        private List<Department> leftDepartments;
        public List<Department> LeftDepartments
        {
            get { return leftDepartments; }
            set { leftDepartments = value; }
        }

        // RIGHT DEPARTMENTS LIST
        private List<Department> rightDepartments;
        public List<Department> RightDepartments
        {
            get { return rightDepartments; }
            set { rightDepartments = value; }
        }



    }
}
