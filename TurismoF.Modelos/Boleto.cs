using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Boleto
    {
        // Necesarios
        public int Id { get; set; }
        public CategoriaPasajero Categoria { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        public decimal PrecioFinal { get; set; }
        public DateTime FechaEmision { get; set; }
        public EstadoBoleto Estado { get; set; }

        // FKs
        public int? ReservaId { get; set; }
        public int? ViajeId { get; set; }
        public int? AsientoId { get; set; }

        // Navegadores
        public Reserva? Reserva { get; set; }
        public Viaje? Viaje { get; set; }
        public Asiento? Asiento { get; set; }
    }


    public class BoletoEstandar:Boleto { }
    public class BoletoPreferencial:Boleto { }
}
