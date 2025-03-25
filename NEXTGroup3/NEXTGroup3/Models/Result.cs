using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;
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
        public int? CandidateId { get; set; } = null;

        //---DEPARTMENT POINTS---//
        public string DepartmentPoints = "";

        //---ROLES POINTS---//
        public string RolePoints = "";

        //public Result(int? ci = null) {
        //    CandidateId = ci;
        //}

        public void SerializeBothPoints(Point[] departmentPoints, List<Point> rolePoints)
        {
            SerializeDepartmentPoints(departmentPoints); 
            SerializeRolePoints(rolePoints);
        }
        public void SerializeDepartmentPoints(Point[] inputPoints)
        {
            DepartmentPoints =  String.Join("", inputPoints.Select(p => $"{p.Points}+{p.Id},"));
        }
        public void SerializeRolePoints(List<Point> inputPoints)
        {
            RolePoints =  String.Join("", inputPoints.Select(p => $"{p.Points}+{p.Id},")); 
        }
        public Point[] DeserializingDepartmentPoints()
        {
            string[] pointObjects = DepartmentPoints.Split(',');
            Point[] departmentPointArray = new Point[pointObjects.Length];


            for (int i = 0; i < pointObjects.Length; i++)
            {
                string[] pointItems = pointObjects[i].Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                departmentPointArray[i] = p;
            }
            return departmentPointArray;

            //---LEGACY---//
            //foreach (string pointObject in pointObjects)
            //{
            //    string[] pointItems = pointObject.Split('+');
            //    Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
            //    departmentPointArray[p.Id].Points = p.Points;
            //}
        }
        public Point[] DeserializingRolePoints()
        {
            string[] pointObjects = RolePoints.Split(',');
            Point[] rolePointArray = new Point[pointObjects.Length];
            
            for (int i = 0; i < pointObjects.Length; i++)
            {
                string[] pointItems = pointObjects[i].Split('+');
                Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
                rolePointArray[i] = p;
            }
            return rolePointArray;
            
            //---LEGACY---//
            //foreach (string pointObject in pointObjects)
            //{
            //    string[] pointItems = pointObject.Split('+');
            //    Point p = new Point(Convert.ToInt32(pointItems[0]), Convert.ToInt32(pointItems[1]));
            //    rolePointArray[p.Id].Points = p.Points;
            //}
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
