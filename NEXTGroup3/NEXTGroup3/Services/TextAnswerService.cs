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

        public TextAnswerService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
            //context = c;
            //var DbFactory = new AzureContextFactory();
            //contextSecondary = DbFactory.CreateDbContext();
        }
        public async Task<List<TextAnswer>> GetAllTextQuestionsFromRolesInDepartment(Department department)
        {
            var context = contextFactory.CreateDbContext();
            var roles = await context.Role.Where(x => x.DepartmentId == department.Id).AsNoTracking().ToListAsync();
            return await GetTextAnswersFromRoles(roles);
        }
        public async Task<List<TextAnswer>> GetTextAnswersFromRoles(List<Role> roles)
        {

            var tasks = roles.Select(async role =>
            {

                using (var context = contextFactory.CreateDbContext())
                {
                    var result = await GetAllTextAnswersFromRole(role, context);
                    Console.WriteLine($"Fetched {result.Count} answers for RoleId: {role.Id}");
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
