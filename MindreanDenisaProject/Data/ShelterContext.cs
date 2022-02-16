using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindreanDenisaProject.Models;

namespace MindreanDenisaProject.Data
{
    public class ShelterContext: IdentityDbContext<IdentityUser>
    {
        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animale { get; set; }
        public DbSet<TipAnimal> Tipuri { get; set; }
        public DbSet<Adapost> Adaposturi { get; set; }
        public DbSet<Oras> Orase { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Animal>().ToTable("Animale");
            modelBuilder.Entity<TipAnimal>().ToTable("Tipuri Animale");
            modelBuilder.Entity<Adapost>().ToTable("Adaposturi");
            modelBuilder.Entity<Oras>().ToTable("Orase");
        }
    }
}
