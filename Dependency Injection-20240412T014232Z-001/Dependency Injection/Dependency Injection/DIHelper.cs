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

        public object Resolve(Type t)
        {
            if (impls.TryGetValue(t, out var impl))
                return impl;

            if (t.IsInterface || t.IsAbstract)
                throw new Exception("Cannot Resolve Dependency");

            var constructors = t.GetConstructors();
            if (constructors == null && constructors.Length == 0 && constructors.Length > 1)
            {
                throw new Exception("Cannot Resolve Dependency");
            }
            var constructor = constructors.First();
            var parameters = (constructor).GetParameters().Select(a => Resolve(a.ParameterType)).ToArray();
            return constructor.Invoke(parameters);
        }

        Dictionary<Type, object> impls = new Dictionary<Type, object>();
    }
}
