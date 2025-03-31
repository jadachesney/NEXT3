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
        public string DepartmentPoints { get; set; } = "";

        //---ROLES POINTS---//
        public string RolePoints { get; set; } = "";

        public DateTime Timestamp { get; set; }
        
        public Result()
        {
            Timestamp = DateTime.Now;
        }

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
            Point[] departmentPointArray = new Point[pointObjects.Length - 1];


            for (int i = 0; i < departmentPointArray.Length; i++)
            {
                string[] pointItems = pointObjects[i].Split('+');
                departmentPointArray[i] = new Point(Convert.ToInt32(pointItems[1]), Convert.ToInt32(pointItems[0]));
            }
            return departmentPointArray;
        }
        public Point[] DeserializingRolePoints()
        {
            string[] pointObjects = RolePoints.Split(',');
            Point[] rolePointArray = new Point[pointObjects.Length - 1];
            
            for (int i = 0; i < rolePointArray.Length; i++)
            {
                string[] pointItems = pointObjects[i].Split('+');
                rolePointArray[i] = new Point(Convert.ToInt32(pointItems[1]), Convert.ToInt32(pointItems[0]));
            }
            return rolePointArray;
            
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
