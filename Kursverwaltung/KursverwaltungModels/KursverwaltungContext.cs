using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kursverwaltung.Models;

namespace Kursverwaltung.Models
{
  // Reverse from Database
  //https://www.learnentityframeworkcore.com/walkthroughs/existing-database

  public class KursverwaltungContext : DbContext
  {
    public KursverwaltungContext(DbContextOptions<KursverwaltungContext> options)
        : base(options)
    {
    }

    public KursverwaltungContext()
    {

    }

    public DbSet<Kursverwaltung.Models.Kurs> Kurs { get; set; }

    public DbSet<Kursverwaltung.Models.Termin> Termin { get; set; }

    public DbSet<Teilnehmer> Teilnehmer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TeilnehmerTermin>().HasKey(t => new { t.TeilnehmerId, t.TerminId });
    }

    public DbSet<Kursverwaltung.Models.TeilnehmerTermin> TeilnehmerTermin { get; set; }
  }
}
