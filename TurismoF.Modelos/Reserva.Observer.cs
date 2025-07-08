using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using TurismoF.Modelos.Observer;

namespace TurismoF.Modelos
{
    // Extensión partial para Observer Pattern
    public partial class Reserva:INotificationSubject
    {
        private readonly List<INotificationObserver> _observers = new();

        public void Attach(INotificationObserver observer) => _observers.Add(observer);
        public void Detach(INotificationObserver observer) => _observers.Remove(observer);

        // subject: asunto del correo, message: cuerpo, email: destinatario
        public void NotifyObservers(string subject, string message, string email)
        {
            foreach(var obs in _observers)
                obs.Notify(subject, message, email);
        }

        // Ejemplo: cuando la reserva cambia de estado
        public void CambiarEstado(EstadoReserva nuevoEstado, string emailCliente, string emailAdmin)
        {
            // ... lógica de cambio de estado ...

            // Notificar al cliente
            NotifyObservers(
                "Actualización de tu reserva",
                $"Tu reserva cambió de estado a: {nuevoEstado}",
                emailCliente);

            // Notificar al admin (opcional)
            NotifyObservers(
                "Reserva modificada",
                $"La reserva del cliente con email {emailCliente} cambió a: {nuevoEstado}",
                emailAdmin);
        }
    }
}
