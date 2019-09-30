using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DataProviders
{
    interface IBaseProvider <T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        bool Set(T entity);
        long Add(T entity);
        bool Del(long id);
        bool DelAll();
    }
}
