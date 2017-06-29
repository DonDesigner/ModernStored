using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer get(Guid id);

        Customer GetByUserId(Guid id);



    }
}
