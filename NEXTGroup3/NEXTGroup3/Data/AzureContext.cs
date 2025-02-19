using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Models;

namespace NEXTGroup3.Data
{
    public class AzureContext : DbContext
    {
        public AzureContext (DbContextOptions<AzureContext> options)
            : base(options)
        {
        }
      public DbSet<NEXTGroup3.Models.Department> Department { get; set; } = default!;
      public DbSet<NEXTGroup3.Models.Role> Role { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Staff> Staff { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Candidate> Candidate { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.RangeQuestion> RangeQuestion { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Result> Result { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.TextAnswer> TextAnswer { get; set; } = default!;
    }
}
