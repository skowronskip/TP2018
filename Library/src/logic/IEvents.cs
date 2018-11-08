using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public interface IEvents
    {
        void RegisterEvent(Event newEvent);
        List<Event> listEvents();
    }
}
