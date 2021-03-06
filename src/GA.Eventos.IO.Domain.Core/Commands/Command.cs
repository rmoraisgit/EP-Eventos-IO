﻿using GA.Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public Command()
        {
            Datestamp = DateTime.Now;
        }

        public DateTime Datestamp { get; private set; }
    }
}
