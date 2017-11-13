using ModernStore.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Contexts;
using ModernStore.Domain.Commands.Results;
using System.Data.SqlClient;
using Dapper;
using ModernStore.Shared;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;


        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public GetCustomerCommandResult Get(string username)
        {
            /* 
             * Exemplo utilizando o EntityFrameword 
             * 
            return _context
                .Customers
                .Include(x => x.User)
                .AsNoTracking()
                .Select(x => new GetCustomerCommandResult
                {
                    Name = x.Name.ToString(),
                    Document = x.Document.Number,
                    Active = x.User.Active,
                    Email = x.Email.Address,
                    Password = x.User.Password,
                    Username = x.User.Username
                })
                .FirstOrDefault(x => x.Username == username);
             */

            /*
             * Exemplo utilizando o Dapper
             */

            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>("SELECT * FROM [GetCustomerInfoView] WHERE [Active]=1 AND [Username]=@username", new { username=username}).FirstOrDefault();



            }

        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public Customer GetByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer GetByUsername(string username)
        {
           
            try
            {
               var user = _context.
               Customers
               .Include(x => x.User)
               .AsNoTracking()
               .FirstOrDefault(x => x.User.Username == username);

                return user;
            }
            catch (Exception ex)
            {

                var err = ex.Message;
            }
            return null;
           
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);

        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
