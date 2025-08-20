using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Factory_and_Abstract
{
    public class DBFactoryCreator
    {
        public IDatabaseFactory CreateFactory(string configuration)
        {
            if (configuration == "SQLServer")
            {
                return new SQLServerFactory();
            }
            else
            {
                return new MySQlServerFactory();
            }
        }
    }
}