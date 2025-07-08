using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Tren
    {
        // Necesarios
        public int Id { get; set; }
        public string Nombre { get; set; }
        public EstadoTren Estado { get; set; }

        // Nueva lógica para generación automática de asientos
        public int CantidadVagones { get; set; } // Total de vagones que tendrá el tren
        public int CantidadAsientosPorVagon { get; set; } // Asientos por vagon (todos los vagones tendrán la misma cantidad)

        // FKs
        // (Ninguna)

        // Navegadores
        public List<Vagon>? Vagones { get; set; }
        public List<Viaje>? Viajes { get; set; }
    }
}
