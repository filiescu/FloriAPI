using FloriAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI.Data
{
    public class FloriDBContext: DbContext
    {
        public DbSet<Lot> Loturi { get; set; }
        public DbSet<Stoc> Stocuri { get; set; }

        public FloriDBContext()
        {
        }

        public FloriDBContext(DbContextOptions<FloriDBContext> options)
         : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=flori;User Id=sa;Password=mara30;");
        }
    }
}
