using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Data.Repository.IRepository
{
    public interface IRepoWrapper : IDisposable
    {
        //single transactions
        ICategoryRepository Category { get; }
        IServiceRepository Services { get; }
        public void Save();

    }
}
