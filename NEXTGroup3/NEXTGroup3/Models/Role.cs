namespace NEXTGroup3.Models
{
    public class Role
    {
        //-----ATTRIBUTES-----//

        //--ROLE ID--//
        private int id;
        public int Id { get { return id; } set { id = value; } }

        //--ROLE NAME--//
        private string name;
        public string Name { get { return name; } set { name = value; } }

        //--DEPARTMENT ID--//
        private int departmentId;
        public int DepartmentId { get; set; }

        //--ROLE LINK--//
        private string link;
        public string Link { get { return link; } set { link = value; } }
    }
}
