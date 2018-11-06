using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbBeispiel.Models
{
    public partial class MondialCore2Context : DbContext
    {
        public MondialCore2Context()
        {
        }

        public MondialCore2Context(DbContextOptions<MondialCore2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=MondialCore2;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.ContinentId);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentId);
            });
        }
    }
}
