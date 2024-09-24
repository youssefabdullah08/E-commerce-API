using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites
{
    public class BaseEntity<T>
    {
        public T id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
