using GA.Eventos.IO.Domain.Core.Events;
using GA.Eventos.IO.Domain.Eventos.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler :
        IHandler<RegistrarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(
                message.Nome,
                message.DataInicio,
                message.DataFim,
                message.Gratuito,
                message.Valor,
                message.Online,
                message.NomeEmpresa);

            if (!evento.EhValido())
            {
                // Notificar erro
            }

            _eventoRepository.Adicionar(evento);
        }
    }
}
