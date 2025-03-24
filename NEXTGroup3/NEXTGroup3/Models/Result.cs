using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace NEXTGroup3.Models
{
    public class Result
    {
        //-----ATTRIBUTES-----//

        //---RESULT ID---//
        private int id;
        public int Id { get { return id; } set { id = value; } }

        //---CANDIDATE ID---//
        private int candidateId;
        public int CandidateId { get; set; }

        //---DEPARTMENT POINTS---//

        [NotMapped] private Point[] departmentPoints = 
            { new Point(1), 
            new Point(2), 
            new Point(3), 
            new Point(4), 
            new Point(5), 
            new Point(6), };
        [NotMapped] public Point[] DepartmentPointsArray { get { return departmentPoints; } set { departmentPoints = value; } }
        private string DepartmentPoints = "";

        ////---ROLES POINTS---//
        ///
        [NotMapped] private List<Point> rolePointsList = new List<Point>();
        [NotMapped] public List<Point> RolePointsList { get { return rolePointsList; } set { rolePointsList = value; } }
        private string RolePoints = "";
        public void SerializeBothPoints()
        {
            SerializeDepartmentPoints(); 
            SerializeRolePoints();
        }
        public void SerializeDepartmentPoints()
        {
            string depPoints = "";
            DepartmentPointsArray.Select(p => depPoints += $"{p.Points}+{p.Id},");
            DepartmentPoints = depPoints;
        }
        public void SerializeRolePoints()
        {
            string rolePoints = "";
            RolePointsList.Select(p => rolePoints += $"{p.Points}+{p.Id},");
            this.RolePoints = rolePoints;
        }
        public void DeserializingDepartmentPoints(string serializedText)
        {
            string[] pointObjects = serializedText.Split(',');
            foreach (string pointObject in pointObjects)
            {
                string[] pointItems = pointObject.Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                DepartmentPointsArray[p.Id].Points = p.Points;
            }
        }
        public void DeserializingRolePoints(string serializedText)
        {
            string[] pointObjects = serializedText.Split(',');
            foreach (string pointObject in pointObjects)
            {
                string[] pointItems = pointObject.Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                RolePointsList.Add(p);
            }
        }
    }
    [NotMapped]
    public class Point
    {
        private int points;
        private int id;

        public Point(int id, int points = default)
        {
            this.Points = points;
            this.Id = id;
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
