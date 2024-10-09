using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.TokenServece
{
    public interface ITokenServece
    {
        string GenritToken(AppUser appUser);
    }
}
