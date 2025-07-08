using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class Ruta
    {
        // Necesarios
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string UbicacionInicio { get; set; }
        public string UbicacionFin { get; set; }



        // FKs
        // (Ninguna)




        // Navegadores
        public List<Viaje>? Viajes { get; set; }
        public List<PrecioConfiguracion>? PreciosConfiguracion { get; set; }
    }
}