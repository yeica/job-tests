using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        public Estado Estado { get; set; }
        [Display(Name = "Estado Actual")]
        public int EstadoId { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
        public ICollection<Jugador> Jugadores { get; set; }
    }
}
