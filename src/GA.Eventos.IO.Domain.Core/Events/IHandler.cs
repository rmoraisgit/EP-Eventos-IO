﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Core.Events
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T message);
    }
}