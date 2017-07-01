using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, ICommandHandler<RegisterOrderCommand>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {

            // Instância o cliente do lendo do repositorio
            var customer = _customerRepository.Get(command.Customer);

            // Gera um novo pedido
            var order = new Order(customer, command.DeliveryFee, command.Discount);


            //Adiciona os itens no pedido
            foreach (var item in command.Items)
            {
                var prod = _productRepository.Get(item.Product);
                var ordemItem = new OrderItem(prod, item.Quantity);
                order.AddItem(ordemItem);
            }

            // Adiciona as notificações do Pedido no Handler
            AddNotifications(order.Notifications);


            //Persiste no Banco
            if (IsValid())
                _orderRepository.Save(order);

            return new RegisterOrderCommandResult
            {
                Number = order.Number
            };

        }

        ICommandResult ICommandHandler<RegisterOrderCommand>.Handle(RegisterOrderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
