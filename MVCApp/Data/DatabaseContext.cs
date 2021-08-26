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
            modelBuilder.Entity<Equipo>(equipo =>
            {
                equipo.ToTable("TablaEquipo");
                equipo.Property(e => e.Pais).HasMaxLength(3);
            });

            modelBuilder.Entity<Jugador>().ToTable("TablaJugador");

            modelBuilder.Entity<Estado>(estado =>
            {
                estado.ToTable("TablaEstado");
                estado.Property(e => e.NombreEstado).HasConversion<string>();
                estado.HasData(new Estado { Id = 1, NombreEstado = Models.Estados.Activo, FechaCreacion = DateTime.Now });
                estado.HasData(new Estado { Id = 2, NombreEstado = Models.Estados.Cancelado, FechaCreacion = DateTime.Now });
                estado.HasData(new Estado { Id = 3, NombreEstado = Models.Estados.AgenteLibre, FechaCreacion = DateTime.Now });

            });

            string val = nameof(Models.Estados.AgenteLibre);
        }
     
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
