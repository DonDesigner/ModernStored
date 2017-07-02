using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Transaction
{
    public interface IUow
    {
        void Commit();
        void Roolback();
    }
}
