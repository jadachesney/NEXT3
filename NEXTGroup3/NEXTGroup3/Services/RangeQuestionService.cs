using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class RangeQuestionService
    {
        private readonly AzureContext context;

        public RangeQuestionService(AzureContext c)
        {
            context = c;
        }

        public async Task<List<RangeQuestion>> GetAllRangeQuestions()
        {
            return await context.RangeQuestion.AsNoTracking().ToListAsync();
        }
    }
}
