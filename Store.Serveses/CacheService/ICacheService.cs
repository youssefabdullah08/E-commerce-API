using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Serveses.CacheService
{
    public interface ICacheService
    {
        Task SetCacheAsync(string key, string value);
        Task<string> GetCacheAsync(string key);
    }
}
