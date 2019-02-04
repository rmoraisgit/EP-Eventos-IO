using GA.Eventos.IO.Domain.Core.Bus;
using GA.Eventos.IO.Domain.Core.DomainNotifications;
using GA.Eventos.IO.Domain.Core.Events;
using GA.Eventos.IO.Domain.Eventos.Handlers;
using GA.Eventos.IO.Domain.Eventos.Repository;
using GA.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IBus bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _uow = uow;
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

            if (!EventoEhValido(evento)) return;

            if (Commit())
            {
                _eventoRepository.Adicionar(evento);
            }
        }

        private bool EventoEhValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }
    }
}
