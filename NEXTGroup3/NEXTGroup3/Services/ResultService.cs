using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class ResultService
    {
        private IDbContextFactory<AzureContext> contextFactory;
        public Result Result { get; set; }

        public ResultService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
            Result = new Result();
        }
        
        // gets the relationship between departments and range questions
        public async Task<List<DepartmentRangeQuestion>> GetAllDepartmentRangeQuestions()
        {
            var context = contextFactory.CreateDbContext();
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
                Result.RolePointsList.Add(point);
            }
        }

        //---waiting for the result table to be updated---//

        // fetches all results for one user
        //public async Task<List<Result>> GetResultsFromUserId(int userId)
        //{
        //    var context = contextFactory.CreateDbContext();

        //    //return await context.Result.Where(x => x.UserId == userId);
        //}

        // Fetches all results 
        public async Task<List<Result>> GetAllResults()
        {
            var context = contextFactory.CreateDbContext();

            return await context.Result.ToListAsync();
        }

        // saves a result to the database
        public void SaveResult()
        {
            Result.CandidateId = 1;
            Result.SerializeBothPoints();

            var context = contextFactory.CreateDbContext();
            context.Result.Add(Result);
        }
    }
}