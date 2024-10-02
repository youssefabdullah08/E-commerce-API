using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.HandelResponse
{
    public class Response
    {
        public Response(int code, string? message = null)
        {
            StutusCode = code;
            Massage = message ?? getMassage(code);
        }
        public int StutusCode { get; set; }
        public string? Massage { get; set; }

        private string getMassage(int code)
       => code switch
       {
           100 => "Continue - The server has received the request headers.",
           200 => "OK - The request was successful.",
           201 => "Created - The resource was created successfully.",
           400 => "Bad Request - The request was invalid or cannot be served.",
           401 => "Unauthorized - Authentication is required and has failed.",
           403 => " Forbidden - You do not have permission to access this resource.",
           404 => "Not Found - The requested resource could not be found.",
           500 => "Internal Server Error - The server encountered an error.",
           _ => "unknown code"
       };
    }
}
