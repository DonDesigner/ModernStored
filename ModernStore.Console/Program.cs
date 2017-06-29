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
            GenerateOrder(new FakeCustomerRepository(), new FakeProductRepository(), new Guid(), new Dictionary<Guid, int> { { Guid.NewGuid(), 5 } }, 10,20 );
            Console.ReadKey();

        }

        public static void GenerateOrder(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            Guid userId,
            IDictionary<Guid, int> products,  //key o produto - value a quantidade
            decimal deliveryFee,
            decimal discount
            )
        {
            var customer = customerRepository.GetByUserId(userId);

            var order = new Order(customer, deliveryFee, discount);
            foreach (var item in products)
            {
                var prod = productRepository.Get(item.Key);
                order.AddItem(new OrderItem(prod, item.Value));
            }
               
          

            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousePad, 2));
            order.AddItem(new OrderItem(teclado, 2));



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

            if (customer.Notifications.Count != 0)
            {
                Console.WriteLine($"{customer.Notifications}");
            }



        }
    }


    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer get(Guid id)
        {
            return null;
        }

        public Customer GetByUserId(Guid id)
        {
            return new Customer(
            new Name("Diego", "Fernandes"),
            new Email("diego@mail.com"),
            new Document("12345678999"),
            new User("diego", "123")
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
}
