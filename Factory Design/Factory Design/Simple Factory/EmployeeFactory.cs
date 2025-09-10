using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Simple_Factory
{
    public class EmployeeFactory
    {
        public IEmployeeManager CreateEmployee(int emptype)
        {
            if (emptype == 1)
            {
                return new PermanentEmployeeManager();
            }
            else
            {
                return new ContractEmployeeManager();
            }
        }
    }
}
