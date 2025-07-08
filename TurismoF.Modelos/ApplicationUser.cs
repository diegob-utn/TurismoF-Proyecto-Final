using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos
{
    public class ApplicationUser  // :IdentityUser  // integracion con Identity
    {
        public int Id { get; set; }

        // Campos personalizados
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        // Si quieres usar el campo PhoneNumber de IdentityUser, no necesitas redeclararlo.
        // Si quieres lógica personalizada, puedes sobrescribirlo:
        // public override string PhoneNumber { get; set; }

        // Navegadores
        public List<Reserva>? Reservas { get; set; } = new();
        public List<Pago>? Pagos { get; set; } = new();
    }
}
