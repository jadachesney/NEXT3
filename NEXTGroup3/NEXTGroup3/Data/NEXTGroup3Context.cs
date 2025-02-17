using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NEXTGroup3.Models;

namespace NEXTGroup3.Data
{
    public class NEXTGroup3Context : DbContext
    {
        public NEXTGroup3Context (DbContextOptions<NEXTGroup3Context> options)
            : base(options)
        {
        }

        public DbSet<NEXTGroup3.Models.Department> Department { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Role> Role { get; set; } = default!;
        public DbSet<NEXTGroup3.Models.Roles> Roles { get; set; } = default!;
    }
}
