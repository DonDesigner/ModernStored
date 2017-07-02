using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Repositories
{
   public class OrderRepositories : IOrderRepository
    {
        private readonly ModernStoreDataContext _context;

        public OrderRepositories(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
