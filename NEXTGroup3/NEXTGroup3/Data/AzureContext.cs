using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Models;


namespace NEXTGroup3.Data
{
  public class AzureContext(DbContextOptions<AzureContext> options) : IdentityDbContext<NextUser>(options)
  {
    public DbSet<NEXTGroup3.Models.Department> Department { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.Role> Role { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.RangeQuestion> RangeQuestion { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.Result> Result { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.TextAnswer> TextAnswer { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.DepartmentRangeQuestion> DepartmentRangeQuestion { get; set; } = default!;
    public DbSet<NEXTGroup3.Models.EncouragingMessage> EncouragingMessage { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
