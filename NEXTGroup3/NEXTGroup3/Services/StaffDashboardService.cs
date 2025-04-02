using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using NEXTGroup3.Data;
using NEXTGroup3.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEXTGroup3.Services
{
    public class StaffDashboardService
    {
        private readonly IDbContextFactory<AzureContext> contextFactory;
        public List<Point> DepartmentPoints { get; set; } = new List<Point>();
        public List<Point> RolePoints { get; set; } = new List<Point>();
        public List<Department> Departments { get; set; }
        public Department HighestDepartment { get; set; }
        public List<Role> TopRoles { get; set; }
        public int ResultsCount { get; set; }

        public StaffDashboardService(IDbContextFactory<AzureContext> c) 
        {
            contextFactory = c;
        }

        // Fetches all results 
        public async Task<List<Result>> GetAllResults()
        {
            var context = contextFactory.CreateDbContext();

            return await context.Result.ToListAsync();
        }
        public async Task GetOverallPoints(int candidateId = -1)
        {
            AzureContext context = contextFactory.CreateDbContext();
            List<Result> results;
            if(candidateId <= 0) { results = context.Result.ToList(); }
            else { results = context.Result.Where(x => x.CandidateId == candidateId).ToList(); }
            

            int[] departmentIds = await context.Department.Select(d => d.Id).ToArrayAsync();
            int[] roleIds = await context.Role.Select(r => r.Id).ToArrayAsync();

            //--- initialize the overall point lists --- //
            foreach (int id in departmentIds) DepartmentPoints.Add(new Point(id));

            foreach (int id in roleIds) RolePoints.Add(new Point(id));

            foreach (Result result in results)
            {
                Point[] depPoints = result.DeserializingDepartmentPoints();
                for (int i = 0; i < depPoints.Length; i++)
                {
                    DepartmentPoints[i].Points += depPoints[i].Points;
                }

                Point[] rolePoints = result.DeserializingRolePoints();
                for(int i = 0; i < rolePoints.Length; i++)
                {
                    foreach(Point point in RolePoints)
                    {
                        if (point.Id == rolePoints[i].Id)
                        {
                            point.Points += rolePoints[i].Points;
                            break;
                        }
                    }
                }
            }
            ResultsCount = results.Count();
            await GetHighestDepartment();
        }
        public Task GetDepartments()
        {
            var context = contextFactory.CreateDbContext();
            Departments = context.Department.ToList();
            return Task.CompletedTask;
        }

        public async Task<List<string>> GetDepartmentStringList()
        {
            return Departments.Select(x => x.Name).ToList();
        }
        public async Task<List<Double?>> DepartmentPointsToDoubleList()
        {
            List<Double?> output = new List<Double?>();
            foreach (var department in DepartmentPoints) { output.Add(Convert.ToDouble(department.Points)); }
            return output;
        }

        public async Task GetHighestDepartment()
        {
            var context = contextFactory.CreateDbContext();

            Point highestDep = new(0); //placeholder point

            foreach (Point p in DepartmentPoints) {
                if (p.Points > highestDep.Points) highestDep = p;
            }
            if(highestDep != null && Departments != null)
            {
                HighestDepartment = Departments.Find(x => x.Id == highestDep.Id);
            }

            //var sortedDepartments = DepartmentPoints.OrderByDescending(p => p.Points);
            //HighestDepartment = Departments.Where(d => d.Id == sortedDepartments.ElementAt(0).Id).First();
        }
        //public async Task GetTopRoles()
        //{
        //    var context = contextFactory.CreateDbContext();

        //    var topPoints = RolePoints.OrderBy(p => p.Points).Take(5);
        //    TopRoles = context.Roles.Where(r => topPoints.Any(p => r.Id == p.Id)).ToList();
        //}
    }
}
