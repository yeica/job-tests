using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string País { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public ICollection<Jugador> Jugadores { get; set; }
    }
}
