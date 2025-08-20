using Factory_Design.Simple_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Factory_Design_Pattern
{
    public class EmployeeManagerFactory
    {
        public BaseEmployeeFactory CreateFactory(Employee employee)
        {
            if (employee.EmployeeType == 1)
            {
                return new PermanentEmployeeFactory(employee);
            }
            else
            {
                return new ContractEmployeeFactory(employee);
            }
        }
    }
}
