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

        //---DEPARTMENT POINTS---//
        [NotMapped] private Point[] departmentPoints = 
            { new Point(1), 
            new Point(2), 
            new Point(3), 
            new Point(4), 
            new Point(5), 
            new Point(6), };
        [NotMapped] public Point[] DepartmentPoints { get { return departmentPoints; } set { departmentPoints = value; } }

        ////---ROLES POINTS---//
        [NotMapped] private List<Point> rolePoints;
        [NotMapped] public List<Point> RolePoints { get { return rolePoints; } set { rolePoints = value; } }

        public string SerializingDepartmentPoints()
        {
            string depPoints = "";
            DepartmentPoints.Select(p => depPoints += $"{p.Points}+{p.Id},");
            return depPoints;
        }
        public string SerializingRolePoints()
        {
            string rolePoints = "";
            RolePoints.Select(p => rolePoints += $"{p.Points}+{p.Id},");
            return rolePoints;
        }
        public void DeserializingDepartmentPoints(string serializedText)
        {
            string[] pointObjects = serializedText.Split(',');
            foreach (string pointObject in pointObjects)
            {
                string[] pointItems = pointObject.Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                DepartmentPoints[p.Id].Points = p.Points;
            }
        }
        public void DeserializingRolePoints(string serializedText)
        {
            string[] pointObjects = serializedText.Split(',');
            foreach (string pointObject in pointObjects)
            {
                string[] pointItems = pointObject.Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                RolePoints.Add(p);
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
