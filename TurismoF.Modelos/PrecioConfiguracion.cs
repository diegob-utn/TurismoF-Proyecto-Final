using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class PrecioConfiguracion
    {
        // Necesarios
        public int Id { get; set; }
        public CategoriaPasajero Categoria { get; set; }
        public TipoAsiento TipoAsiento { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal Descuento { get; set; } // % de descuento por promoción/categoría

        // FKs
        public int? RutaId { get; set; }

        // Navegadores
        public Ruta? Ruta { get; set; }
    }
}
