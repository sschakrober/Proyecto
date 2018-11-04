using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IELChak.Models
{
    public class IELChakContext : DbContext
    {
        public IELChakContext (DbContextOptions<IELChakContext> options)
            : base(options)
        {
        }

        public DbSet<IELChak.Models.Categoria> Categoria { get; set; }
    }
}
