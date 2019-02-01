using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Core.Events
{
    public abstract class Message
    {
        public Message()
        {
            MessageType = GetType().Name;
        }

        public Guid AggregateId { get; protected set; }
        public string MessageType { get; private set; }
    }
}
