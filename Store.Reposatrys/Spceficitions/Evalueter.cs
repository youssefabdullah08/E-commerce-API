using Microsoft.EntityFrameworkCore;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions
{
    public class Evalueter<T> where T : class
    {
        public static IQueryable<T> Getquery(IQueryable<T> inputquery, ISpecifiction<T> specifiction)
        {
            var query = inputquery;

            if (specifiction.craiteria != null)
                query = query.Where(specifiction.craiteria);

            if (specifiction.Ispagneted)
                query = query.Skip(specifiction.Skip).Take(specifiction.Take);

            query = specifiction.includes
                .Aggregate(query, (current, expretion) => current.Include(expretion));

            return query;
        }

    }
}
