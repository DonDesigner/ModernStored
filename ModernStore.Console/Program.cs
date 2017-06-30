using ModernStore.Domain.Command;
using ModernStore.Domain.CommandHandlers;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.conso
{
    class Program

    {
        static void Main(string[] args)
        {
            var command = new RegisterOrderCommand
            {
                Customer = Guid.NewGuid(),
                DeliveryFee = 9,
                Discount = 30,
                Items = new List<RegisterOrderItemCommand>
                    {
                        new RegisterOrderItemCommand
                        {
                           Product = Guid.NewGuid(),
                           Quantity = 3
                        }
                    }
            };


            GenerateOrder(
                new FakeCustomerRepository(), 
                new FakeProductRepository(), 
                new FakeOrderRepository(),
                command);
            Console.ReadKey();

        }



        public static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            RegisterOrderCommand command
            )
        {

            var handler = new OrderCommandHandler(customerRepository, productRepository, orderRepository);

            handler.Handle(command);

            if (handler.IsValid())
                Console.WriteLine("Pedido cadastrado com sucesso!");

            /*
            Console.WriteLine($"Número do Pedido: {order.Number}");
            Console.WriteLine($"Data: { order.CreateDate:dd/MM/yyyy}");
            Console.WriteLine($"Desconto: { order.Discount}");
            Console.WriteLine($"Taxa de Entrega: { order.DeliveryFee}");
            Console.WriteLine($"Sub Total: {order.SubTotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {order.Customer.Name}");

            
            Console.WriteLine("-Estoque-----------------------------");
            Console.WriteLine($"Mouses {mouse.QuantityOnHand}");
            Console.WriteLine($"MousePads {mousePad.QuantityOnHand}");
            Console.WriteLine($"Teclados {teclado.QuantityOnHand}");
            Console.WriteLine("-------------------------------------");
            */


        }
    }


    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByUserId(Guid id)
        {
            return new Customer(
            new Name("Felipe", "Dinis"),
            new Email("lfdf@mail.com"),
            new Document("00987654322"),
            new User("felipe", "543")
                );
        }
    }

    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Product Get(Guid id)
        {
            return new Product("Mouse", 299, "", 50);
        }
    }

    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
           
        }
    }
}
