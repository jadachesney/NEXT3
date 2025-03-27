using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace NEXTGroup3.Data
{
    public class AzureContext(DbContextOptions<AzureContext> options) : IdentityDbContext<NextUser>(options)
    {
      public DbSet<NEXTGroup3.Models.Department> Department { get; set; } = default!;
      public DbSet<NEXTGroup3.Models.Role> Role { get; set; } = default!;
        //public DbSet<NEXTGroup3.Models.Staff> Staff { get; set; } = default!;
        //public DbSet<NEXTGroup3.Models.Candidate> Candidate { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.RangeQuestion> RangeQuestion { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Result> Result { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.TextAnswer> TextAnswer { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
