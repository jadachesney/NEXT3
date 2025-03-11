using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class ResultService
    {
        private readonly AzureContext context;
        public Result Result { get; set; }

        public ResultService(AzureContext c)
        {
            context = c;
            Result = new Result();
        }

        public async Task<List<DepartmentRangeQuestion>> GetAllDepartmentRangeQuestions()
        {
            return await context.DepartmentRangeQuestion.AsNoTracking().ToListAsync();
        }
    }
}
