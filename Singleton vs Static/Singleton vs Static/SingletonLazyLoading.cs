using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_vs_Static
{
    public sealed class SingletonEagerLoading
    {
        private SingletonEagerLoading() // No class will able to inherit not even nested classes
        {

        }

        private static readonly SingletonEagerLoading instance = new SingletonEagerLoading();

        public SingletonEagerLoading GetInstance()
        {
            return instance;
        }

    }
    public sealed class SingletonLazyLoading
    {
        private SingletonLazyLoading() // No class will able to inherit not even nested classes
        {

        }

        private static readonly Lazy<SingletonLazyLoading> instance = new Lazy<SingletonLazyLoading>();

        public SingletonLazyLoading GetInstance()
        {
            return instance.Value;
        }
    }

    public sealed class SingletonDoubleLocking
    {
        private SingletonDoubleLocking() // No class will able to inherit not even nested classes
        {

        }

        private SingletonDoubleLocking instance;
        private object locker = new object(); // this is required for locking even in 

        public SingletonDoubleLocking GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                    if (instance == null)
                        instance = new SingletonDoubleLocking();
            }
            return instance;
        }

    }
}
