using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class RoleService
    {
        private readonly AzureContext context;
        private readonly IDbContextFactory<AzureContext> contextFactory;

        public RoleService(IDbContextFactory<AzureContext> c)
        {
            contextFactory = c;
        }

        public async Task<List<Role>> GetAllRolesInDepartment(Department department)
        {
            var context = contextFactory.CreateDbContext();
            return await context.Role.Where(x=>x.DepartmentId == department.Id).AsNoTracking().ToListAsync();
        }
        public int GetRoleIdFromTextQuestion(int answerId)
        {
            var context = contextFactory.CreateDbContext();

            var textAnswer = context.TextAnswer.Find(answerId);
            if (answerId != 0) 
            { 
                return context.Role.Where(x => x.Id == textAnswer.RoleId).First().Id; 
            }
            else 
            { 
                return 0; 
            }
        }
    }
}