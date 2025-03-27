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

        public StaffDashboardService(IDbContextFactory<AzureContext> c) 
        {
            contextFactory = c;
            GetOverallPoints();
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

            List<Result> results = await context.Result.ToListAsync();

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
    }
}
