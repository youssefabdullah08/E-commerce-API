using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions
{
    public interface ISpecifiction<T>
    {
        Expression<Func<T, bool>> craiteria { get; }
        List<Expression<Func<T, object>>> includes { get; }
        int Take { get; }
        int Skip { get; }
        bool Ispagneted { get; }
    }
}
