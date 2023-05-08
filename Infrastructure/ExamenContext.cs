using ApplicationCore.Domain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamenContext:DbContext
    {
        //DbSet
        public DbSet<Activite> Activities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }

        //OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AgenceVoyageDB;Integrated Security=true;
              MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }
        //OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Activite>().OwnsOne(a => a.Zone);
            modelBuilder.ApplyConfiguration(new ActiviteConfiguration());
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.ClientFk, r.PackFk });
            modelBuilder.Entity<Client>().HasOne(c => c.Conseiller)
                .WithMany(cons => cons.Clients)
                .HasForeignKey(c => c.ConseillerFk)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
        //ConfigureConventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
