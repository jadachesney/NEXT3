using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;



namespace NEXTGroup3.Services
{
    public class TextAnswerService
    {
        // a context factory for providing appropriate access to the database
        private readonly IDbContextFactory<AzureContext> contextFactory;

        //functions are run once before refering to text questions, so current index increases by one before starting the set of quesitons
        public int CurrentQuestionIndex { get; set; } = -1;

        public TextAnswerService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
        }

        // uses functions below to retrieve all text answers relating to the provided department
        public async Task<List<TextAnswer>> GetTextAnswersFromDepartment(Department department)
        {            
            var context = contextFactory.CreateDbContext();
            var roles = context.Role.Where(x => x.DepartmentId == department.Id).AsNoTracking().ToList();
            return await GetTextAnswersFromRoles(roles);
        }
        
        // retrieves all roles within a provided department
        //public async Task<List<Role>> GetRolesFromDepartment(Department department)
        //{

        //}

        // retrieves the text answers from all roles in the derpartment
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

        // retrieves text answers from each individual role
        private async Task<List<TextAnswer>> GetAllTextAnswersFromRole(Role role, AzureContext context)
        {
            return await context.TextAnswer.Where(x => x.RoleId == role.Id).ToListAsync();
        }

        
        public async Task<Role> GetRoleFromTextAnswerId(int id)
        {
            var context = contextFactory.CreateDbContext();
            var textAnswer = context.TextAnswer.Find(id);
            return context.Role.Find(textAnswer.RoleId);
        }
    }
}
