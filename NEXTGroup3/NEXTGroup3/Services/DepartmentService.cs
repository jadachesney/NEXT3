using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Data;
using NEXTGroup3.Models;

namespace NEXTGroup3.Services
{
    public class DepartmentService
    {
        private readonly AzureContext context;

        public DepartmentService(AzureContext c)
        {
            context = c;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await context.Department.AsNoTracking().ToListAsync();
        }
    }
}
