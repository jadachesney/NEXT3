using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class RoleService
    {
        private readonly AzureContext context;

        public RoleService(AzureContext c)
        {
            context = c;
        }

        public async Task<List<Role>> GetAllRolesInDepartment(Department department)
        {
            return await context.Role.Where(x=>x.DepartmentId == department.Id).AsNoTracking().ToListAsync();
        }
    }
}