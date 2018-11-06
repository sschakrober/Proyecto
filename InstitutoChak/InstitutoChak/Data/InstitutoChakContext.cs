using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstitutoChak.Models
{
    public class InstitutoChakContext : DbContext
    {
        public InstitutoChakContext (DbContextOptions<InstitutoChakContext> options)
            : base(options)
        {
        }

        public DbSet<InstitutoChak.Models.Categoria> Categoria { get; set; }
    }
}
