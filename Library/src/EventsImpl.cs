using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.src
{
    public class Events : IEvents
    {
        private List<Event> allEvents = new List<Event>();

        public List<Event> listEvents()
        {
            return allEvents;
        }

        public void RegisterEvent(Event newEvent)
        {
            allEvents.Add(newEvent);
        }
    }
}
