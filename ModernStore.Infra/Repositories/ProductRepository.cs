using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<GetProductListCommandResult> Get()
        {
            using (var conn = new SqlConnection(@"Data Source=DON\SQLEXPRESS;Initial Catalog=ModernStored;User ID=sa;Password=admin"))
            {
                conn.Open();
                return conn.Query<GetProductListCommandResult>("SELECT [id], [title], [price], [image] from Product");
                
            }
        }

        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }
    }
}
