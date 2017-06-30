using FluentValidator;
using ModernStore.Domain.Command;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandHandlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Handle(UpdateCustomerCommand command)
        {
            //Passo 1. Recuperar o cliente
            var customer = _customerRepository.Get(command.Id);

            //Passo 2. Caso o cliente não exista
            if(customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado.");
                return;
            }

            // Passo 3. Atualizar a entidade
            var name = new Name(command.FirstName, command.LastName);
            customer.Update(name, command.BirthDate);

            //Passo 4. Adicionar as notificações
            AddNotifications(customer.Notifications);

            //Pass0 5. Persistir no banco
            if (customer.isValid())
                _customerRepository.Update(customer);

        }

    }
}
