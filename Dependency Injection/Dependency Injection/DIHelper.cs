using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class Container
    {
        public void Register<T>(object value)
        {
            impls.Add(typeof(T), value);
        }

        public T Resolve<T>()
        {
            if (impls.TryGetValue(typeof(T), out var impl))
                return (T)impl;

            if (typeof(T) == typeof(TokenProvider))
            {
                return (T)((new TokenProvider(Resolve<IDateTimeProvider>(), Resolve<IEncryptor>())) as object);
            }
            return default(T);
        }

        Dictionary<Type, object> impls = new Dictionary<Type, object>();
    }
}
