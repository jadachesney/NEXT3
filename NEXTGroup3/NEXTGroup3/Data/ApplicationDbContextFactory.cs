using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace NEXTGroup3.Data
{
    public class AzureContextFactory : IDbContextFactory<AzureContext>
    {
        public AzureContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AzureContext>();
            optionsBuilder.UseSqlServer("Server=tcp:nextgroup3server.database.windows.net,1433;Initial Catalog=NEXTGroup3;Persist Security Info=False;User ID=JadaAdmin;Password=kqYBW3Fehrh4Ru@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new AzureContext(optionsBuilder.Options);
        }
    }
}
