using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Reserva
    {
        // Necesarios
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public EstadoReserva Estado { get; set; }

        // FKs
        public int ApplicationUserId { get; set; }
        public int ViajeId { get; set; }

        // Navegadores
        public ApplicationUser? ApplicationUser { get; set; }
        public Viaje? Viaje { get; set; }
        public List<Boleto>? Boletos { get; set; }
        public List<Pago>? Pagos { get; set; }
    }
}
