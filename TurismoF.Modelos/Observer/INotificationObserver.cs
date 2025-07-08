using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoF.Modelos.Observer
{
    public interface INotificationObserver
    {
        void Notify(string subject, string message, string email);
    }
}
