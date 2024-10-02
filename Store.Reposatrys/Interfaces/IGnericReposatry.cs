using Store.Data.Entites;
using Store.Reposatrys.Spceficitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Interfaces
{
    public interface IGnericReposatry<T> where T : BaseEntity<int>
    {
        Task Add(T item);
        void Update(T item);
        void Delete(T item);
        Task<IReadOnlyList<T>> GetAll(ISpecifiction<T> specs);
        Task<IReadOnlyList<T>> GetAll();

        Task<T> GetbyidWithSpecs(ISpecifiction<T> specs);
        Task<T> Getbyid(int id);


    }
}
