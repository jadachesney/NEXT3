using System.Security.Permissions;

namespace NEXTGroup3.Models
{
    public class Result
    {
        //-----ATTRIBUTES-----//

        //---RESULT ID---//
        private int id;
        public int Id { get { return id; } set { id = value; } }

        //---DEPARTMENT---//
        private Department department;
        public Department Department { get { return department; } set { department = value; } }

        //---DEPARTMENT POINTS---//
        public enum departmentPoints
        {
            IT,
            Finance,
            Marketing,
            Design,
            Trading,
            Merchandising
        }
        public class Foo
        {
            public departmentPoints DepartmentPoints { get; set; }
        }


        //---ROLES---//
        public enum roles { };
        public class Fooo
        {
            public roles Roles { get; set; }
        }
    }
}
