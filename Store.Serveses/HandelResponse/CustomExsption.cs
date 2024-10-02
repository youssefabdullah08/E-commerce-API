using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.HandelResponse
{
    public class CustomExsption : Response
    {
        public CustomExsption(int code, string? message = null, string? details = null) : base(code, message)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}
