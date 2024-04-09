using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melygarazs.Models
{
    internal class MelygarazsAdatbazis : DbContext
    {
        public DbSet<Auto> autok { get; set; }
        public DbSet<Parkolas> parkolasok { get; set; }
        public DbSet<Dij> dijak { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=127.0.0.1;USERNAME=root;PASSWORD=;DATABASE=MelygarazsAdatbazis");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dij>().HasKey(pk => new {pk.Rendszam, pk.Vege});
        }
    }
}
