using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCApp.Models;

namespace MVCApp.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>().Property(e => e.País).HasMaxLength(3);
            modelBuilder.Entity<Equipo>().ToTable("TablaEquipo");
            modelBuilder.Entity<Jugador>().ToTable("TablaJugador");
            modelBuilder.Entity<Estado>().ToTable("TablaEstado");
        }
     
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
