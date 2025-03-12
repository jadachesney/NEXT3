using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class ResultService
    {
        private IDbContextFactory<AzureContext> contextFactory;
        public Result result { get; set; }

        public ResultService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
            Result = new Result();
        }
        
        // gets the relationship between departments and range questions
        public async Task<List<DepartmentRangeQuestion>> GetAllDepartmentRangeQuestions()
        {
            return await context.DepartmentRangeQuestion.AsNoTracking().ToListAsync();
        }

        // fills rolePoints list based on the selected department
        public void InitializeRolePoints(Department department)
        {
            var context = contextFactory.CreateDbContext();

            //finds all roles within the given department
            var roles = context.Role.Where(x => x.DepartmentId == department.Id).AsNoTracking().ToList();

            //adds point objects for each role
            for (int i = 0; i < roles.Count(); i++)
            {
                var point = new Point(roles[i].Id);
                result.RolePoints.Add(point);
            }
        }
    }
}
