using Geek.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geek.DataContexts
{
    public class GeekContext : DbContext
    {
        public virtual DbSet<CalcResult> calcResults { get; set; }

        public GeekContext(DbContextOptions<GeekContext> options) : base(options) { }
    }
}
