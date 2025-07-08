using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TurismoF.Modelos.Observer
{
    public interface INotificationSubject
    {
        void Attach(INotificationObserver observer);
        void Detach(INotificationObserver observer);
        void NotifyObservers(string subject, string message, string email);
    }
}
