using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchIt.Contracts;
//using WrenchIt.Contracts;

namespace WrenchIt.Data.RepositoryBase.IRepository
{
    public interface IRepoWrapper : IDisposable
    {
        //single transactions
        IServiceRepository Service { get; }
        IServiceTypeRepository ServiceType { get; }

        ICarRepository Car { get; }
        ICustomerRepository Customer { get; }
        IEmployeeRepository Employee { get; }

        public void Save();

    }
}
