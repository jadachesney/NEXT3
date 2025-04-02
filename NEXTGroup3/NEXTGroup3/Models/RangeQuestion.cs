using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NEXTGroup3.Models
{
    public class RangeQuestion : Question
    {

        // LEFT DEPARTMENTS LIST
        private List<Department> leftDepartments = new List<Department>();
        public List<Department> LeftDepartments
        {
            get { return leftDepartments; }
            set { leftDepartments = value; }
        }

        // RIGHT DEPARTMENTS LIST
        private List<Department> rightDepartments = new List<Department>();
        public List<Department> RightDepartments
        {
            get { return rightDepartments; }
            set { rightDepartments = value; }
        }

        public void SetDepartments(List<DepartmentRangeQuestion> departmentRangeQuestions, List<Department> departments)
        {
            foreach(DepartmentRangeQuestion dpr in departmentRangeQuestions)
            {
                if(dpr.RangeQuestionId == this.Id)
                {
                    Department? depToAdd = departments.Where(d => d.Id == dpr.DepartmentId).FirstOrDefault();

                    if (depToAdd == null)
                        Console.WriteLine("No departments found");
                    else if (dpr.Alignment)
                        this.RightDepartments.Add(depToAdd);
                    else
                        this.LeftDepartments.Add(depToAdd);
                }
            }
        }
    }
}
