using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace NEXTGroup3.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<NEXTGroup3Context>
    {
        public NEXTGroup3Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NEXTGroup3Context>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new NEXTGroup3Context(optionsBuilder.Options);
        }
    }
}
