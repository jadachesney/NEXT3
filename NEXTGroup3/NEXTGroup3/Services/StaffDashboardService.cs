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
        public async Task GetOverallPoints()
        {
            AzureContext context = contextFactory.CreateDbContext();

            List<Result> results = context.Result.ToList();

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
        }
        public async Task GetDepartments()
        {
            var context = contextFactory.CreateDbContext();
            Departments = await context.Department.ToListAsync();
        }
        public async Task<List<string>> GetDepartmentStringList()
        {
            var context = contextFactory.CreateDbContext();

            return await context.Department.Select(x => x.Name).ToListAsync();
            
        }
        public List<Double?> DepartmentPointsToDoubleList()
        {
            List<Double?> output = new List<Double?>();
            foreach (var department in DepartmentPoints) { output.Add(Convert.ToDouble(department.Points)); }
            return output;
        }
    }
}
