using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Simple_Factory
{
    public interface IEmployeeManager
    {
        double GetBonus();
        double GetSalary();
    }
}
