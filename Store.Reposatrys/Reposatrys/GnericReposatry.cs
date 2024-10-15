using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Spceficitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Reposatrys
{
    public class GnericReposatry<T> : IGnericReposatry<T> where T : BaseEntity<int>
    {
        private readonly StoreDBcontext _context;

        public GnericReposatry(StoreDBcontext context)
        {
            _context = context;
        }

        public async Task Add(T item)
          => await _context.Set<T>().AddAsync(item);

        public void Delete(T item)
        => _context.Set<T>().Remove(item);

        public async Task<IReadOnlyList<T>> GetAll(ISpecifiction<T> specs)
         => await Evalueter<T>.Getquery(_context.Set<T>(), specs).ToListAsync();


        public async Task<T> GetbyidWithSpecs(ISpecifiction<T> specs)
       => await Evalueter<T>.Getquery(_context.Set<T>(), specs).FirstOrDefaultAsync();

        public async Task<T> Getbyid(int? id)
        {
            if (id != null)
                return await _context.Set<T>().FindAsync(id);

            throw new Exception("id must has a value");
        }

        public void Update(T item)
       => _context.Set<T>().Update(item);

        public async Task<IReadOnlyList<T>> GetAll()
        => await _context.Set<T>().ToListAsync();
    }
}
