using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class TextAnswerService
    {
        private readonly AzureContext context;

        public TextAnswerService(AzureContext c)
        {
            context = c;
        }

        public async Task<List<TextAnswer>> GetAllTextAnswers()
        {
            return await context.TextAnswer.AsNoTracking().ToListAsync();
        }
    }
}
