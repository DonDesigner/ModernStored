using ModernStore.Domain.Entities;
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
            var user = new User("Dieog", "123");
            var customer = new Customer("Diego", "Fernandes", "diego@mail.com", user);

            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);
            var mousePad = new Product("Mouse Pad", 99, "mousepad.jpg", 20);
            var teclado = new Product("Teclado", 599, "teclado.jpg", 20);

            Console.WriteLine("-Estoque-----------------------------");
            Console.WriteLine($"Mouses {mouse.QuantityOnHand}");
            Console.WriteLine($"MousePads {mousePad.QuantityOnHand}");
            Console.WriteLine($"Teclados {teclado.QuantityOnHand}");
            Console.WriteLine("-------------------------------------");


            var order = new Order(customer, 8, 10);

            order.AddItem(new OrderItem(mouse, 2));
            order.AddItem(new OrderItem(mousePad, 2));
            order.AddItem(new OrderItem(teclado, 2));



            Console.WriteLine($"Número do Pedido: {order.Number}");
            Console.WriteLine($"Data: { order.CreateDate:dd/MM/yyyy}");
            Console.WriteLine($"Desconto: { order.Discount}");
            Console.WriteLine($"Taxa de Entrega: { order.DeliveryFee}");
            Console.WriteLine($"Sub Total: {order.SubTotal()}");
            Console.WriteLine($"Total: {order.Total()}");
            Console.WriteLine($"Cliente: {order.Customer.ToString()}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-Estoque-----------------------------");
            Console.WriteLine($"Mouses {mouse.QuantityOnHand}");
            Console.WriteLine($"MousePads {mousePad.QuantityOnHand}");
            Console.WriteLine($"Teclados {teclado.QuantityOnHand}");

            Console.ReadKey();
           

        }
    }
}
