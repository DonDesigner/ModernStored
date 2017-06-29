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
            var user = new User("diego", "diego123");

            var customer = new Customer("Diego", "Fernandes", "diego@mail.com", user);
  

            Console.WriteLine($"{customer.FirstName} {customer.LastName} :/ Ativo:{customer.User.Active.ToString()} ");
            Console.ReadKey();
           

        }
    }
}
