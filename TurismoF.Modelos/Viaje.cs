using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Viaje
    {
        // Necesarios
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public EstadoViaje Estado { get; set; }

        // FKs
        public int RutaId { get; set; }
        public int TrenId { get; set; }

        // Navegadores
        public Ruta? Ruta { get; set; }
        public Tren? Tren { get; set; }
        public List<Reserva>? Reservas { get; set; }
        public List<Boleto>? Boletos { get; set; }
    }
}
