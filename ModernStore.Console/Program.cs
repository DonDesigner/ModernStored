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

            var customer = new Customer("ab", "cd", "diego@mail.com", user);
  
            if(!customer.isValid())
            {
                foreach(var notification in customer.Notifications)
                {
                    Console.WriteLine(notification.Message);
                }
            }


            Console.WriteLine($"{customer.FirstName} {customer.LastName} :/ Ativo:{customer.User.Active.ToString()} ");
            Console.ReadKey();
           

        }
    }
}
