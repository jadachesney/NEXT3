using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;



namespace NEXTGroup3.Services
{
    public class TextAnswerService
    {
        //private readonly AzureContext context;
        //private readonly AzureContext contextSecondary;
        private readonly IDbContextFactory<AzureContext> contextFactory;
        public int CurrentQuestionIndex { get; set; } = -1;
        //functions are run once before refering to text questions, so current index increases by one before starting the set of quesitons

        public TextAnswerService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
        }
        public async Task<List<TextAnswer>> GetAllTextQuestionsFromRolesInDepartment(Department department)
        {
            var context = contextFactory.CreateDbContext();
            var roles = context.Role.Where(x => x.DepartmentId == department.Id).AsNoTracking().ToList();
            return await GetTextAnswersFromRoles(roles);
        }
        public async Task<List<TextAnswer>> GetTextAnswersFromRoles(List<Role> roles)
        {

            var tasks = roles.Select(async role =>
            {

                using (var context = contextFactory.CreateDbContext())
                {
                    var result = await GetAllTextAnswersFromRole(role, context);
                    return result;
                }
            }).ToList();

            var results = await Task.WhenAll(tasks);
            return results.SelectMany(x => x).ToList();
        }
        
        private async Task<List<TextAnswer>> GetAllTextAnswersFromRole(Role role, AzureContext context)
        {
            return await context.TextAnswer.Where(x => x.RoleId == role.Id).ToListAsync();
        }
    }
}
