using FluentValidation.Results;
using GA.Eventos.IO.Domain.Core.Bus;
using GA.Eventos.IO.Domain.Core.DomainNotifications;
using GA.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA.Eventos.IO.Domain.Eventos.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow,
                              IBus bus,
                              IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        public void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(erro.PropertyName, erro.ErrorMessage));
            }
        }
        
        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("FAZER ALGO P VALIDAR O ERRO");
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));

            return false;
        }
    }
}
