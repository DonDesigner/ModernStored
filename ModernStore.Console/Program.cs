using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Diego", "Fernandes", new DateTime(1980, 12, 24), "1234", "diego@mail.com");

            customer.Activate();

            Console.WriteLine($"{customer.FirstName} {customer.LastName} Está ativo:{customer.Active.ToString()}");
            Console.ReadKey();
        }

     
    }
}
