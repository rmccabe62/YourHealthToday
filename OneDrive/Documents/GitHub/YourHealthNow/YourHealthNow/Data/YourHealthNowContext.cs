using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourHealthNow.Models;

namespace YourHealthNow.Data
{
    public class YourHealthNowContext : DbContext
    {
        public YourHealthNowContext (DbContextOptions<YourHealthNowContext> options)
            : base(options)
        {
        }

        public DbSet<YourHealthNow.Models.HealthAccess> HealthAccess { get; set; } = default!;

        public DbSet<YourHealthNow.Models.HealthInfo>? HealthInfo { get; set; }
    }
}
