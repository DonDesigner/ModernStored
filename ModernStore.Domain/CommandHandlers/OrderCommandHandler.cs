using FluentValidator;
using ModernStore.Domain.Command;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.CommandHandlers
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

        public void Handle(RegisterOrderCommand command)
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
            if (order.IsValid())
                _orderRepository.Save(order);

        }
    }
}
