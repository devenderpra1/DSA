using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMimic
{
    public class DataType
    {
        public bool IsVersioned { get; set; }

        public string Type { get; set; }
    }

    public class DataType<T> : DataType
    {

    }
}
