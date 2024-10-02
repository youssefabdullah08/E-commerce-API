using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.HandelResponse
{
    public class ValidtionResponse : CustomExsption
    {
        public ValidtionResponse() : base(400)
        {
        }
    }
}
