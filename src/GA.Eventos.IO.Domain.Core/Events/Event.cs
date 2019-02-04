using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Datestamp { get; private set; }

        public Event()
        {
            Datestamp = DateTime.Now;
        }
    }
}
