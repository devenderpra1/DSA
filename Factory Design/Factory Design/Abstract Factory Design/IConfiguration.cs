using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Abstract_Factory_Design
{
    public interface IConfiguration
    {
        string GetBrand();
        string GetProcessor();
    }
}
