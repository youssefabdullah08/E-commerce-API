
using Store.Data.Entites.OrderEntityies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Reposatrys.Spceficitions.OrderSpecs
{
    public class OrderWithSpecs : BaseSpceifictions<Order>
    {
        public OrderWithSpecs(string buyerEmail)
            : base(x => x.BuyerEmail == buyerEmail)
        {
            AddIncludes(x => x.dlivaryMethod);
            AddIncludes(x => x.orderItems);

        }
        public OrderWithSpecs(Guid id)
            : base(x => x.Id == id)
        {
            AddIncludes(x => x.dlivaryMethod);
            AddIncludes(x => x.orderItems);

        }
    }
}
