using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions
{
    public class BaseSpceifictions<T> : ISpecifiction<T>
    {
        public BaseSpceifictions(Expression<Func<T, bool>> criteria)
        {
            craiteria = criteria;
        }
        public Expression<Func<T, bool>> craiteria { get; }

        public List<Expression<Func<T, object>>> includes { get; } = new List<Expression<Func<T, object>>>();
        protected void AddIncludes(Expression<Func<T, object>> include)
        {
            includes.Add(include);
        }
    }
}
