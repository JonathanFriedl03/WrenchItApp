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
       // ICategoryRepository Category { get; }
        IServiceRepository Service { get; }
       IServiceTypeRepository ServiceType { get; }
        public void Save();

    }
}
