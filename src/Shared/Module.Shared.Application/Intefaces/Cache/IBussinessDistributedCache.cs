using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Shared.Application.Cache.Intefaces
{
    public interface IBussinessDistributedCache<T> where T : class
    {
        Task SetItemAsync(string key, T item);
        Task<T> GetItemAsync(string key);
    }
}
