using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrenchIt.Contracts
{
    interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        //Add other relevant models here { get; }
        void Save();
    }
}
