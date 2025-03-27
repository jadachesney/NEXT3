using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class EncouragingMessageService
    {
        private readonly AzureContext context;
        public int IndexForMessage { get; set; } = -1;
        public int Frequency { get; set; } = 0;
        public int MessageCount { get; set; } = 0;

        public EncouragingMessageService(AzureContext c)
        {
            context = c;
        }

        public async Task<List<EncouragingMessage>> GetAllMessages()
        {
            return await context.EncouragingMessage.AsNoTracking().ToListAsync();
        }

        public void IncreaseIndexForMessage()
        {
            IndexForMessage += Frequency;
            MessageCount++;
        } 
    } 
}
