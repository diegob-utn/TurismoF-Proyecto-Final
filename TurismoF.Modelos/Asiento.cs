using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Asiento
    {
        // Necesarios
        public int Id { get; set; }
        public string Codigo { get; set; } // Ej: "A1"
        public TipoAsiento TipoAsiento { get; set; } // Preferencial/Economico

        public UbicacionAsiento Ubicacion { get; set; } // Ventana/Pasillo

        // Nueva lógica para soporte tipo cine
        public string Fila { get; set; }    // Letra de la fila, ej: "A", "B", etc.
        public int Numero { get; set; }     // Número del asiento dentro de la fila, ej: 1, 2, 3...

        // FKs
        public int? VagonId { get; set; }

        // Navegadores
        public Vagon? Vagon { get; set; }
        public List<Boleto>? Boletos { get; set; }
    }
}
