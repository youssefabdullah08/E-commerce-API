using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Interfaces
{
    public interface IUnitOfWork
    {
        IGnericReposatry<T> reposatry<T>();

        Task<int> ComplteAsync();
    }
}
