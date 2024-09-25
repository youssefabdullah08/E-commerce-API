using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Reposatrys.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Reposatrys
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDBcontext context;
        private Hashtable _Repostreies;
        public UnitOfWork(StoreDBcontext context)
        {
            this.context = context;
        }
        public async Task<int> ComplteAsync()
        => await context.SaveChangesAsync();

        public IGnericReposatry<T> reposatry<T>() where T : BaseEntity<int>
        {
            if (_Repostreies is null)
                _Repostreies = new Hashtable();

            var key = typeof(T).Name;

            if (!_Repostreies.ContainsKey(key))
            {
                var Type = typeof(GnericReposatry<>);
                var Instance = Activator.CreateInstance(Type.MakeGenericType(typeof(T)));
                _Repostreies.Add(key, Instance);
            }
            return (IGnericReposatry<T>)_Repostreies[key];
        }
    }
}
