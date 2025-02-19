using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AzureContext context;

        public DataController(AzureContext c)
        {
            this.context = c;
        }

        // GET: api/data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangeQuestion>>> GetAllRangeQuestions()
        {
            var data = await context.RangeQuestion.AsNoTracking().ToListAsync();
            return Ok(data);
        }
        public async Task<ActionResult<IEnumerable<TextAnswer>>> GetAllTextAnswers()
        {
            var data = await context.TextAnswer.AsNoTracking().ToListAsync();
            return Ok(data);
        }
    }
}