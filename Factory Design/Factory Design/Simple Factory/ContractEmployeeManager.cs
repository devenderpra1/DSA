using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Simple_Factory
{
    public class ContractEmployeeManager : IEmployeeManager
    {
        public double GetBonus()
        {
            return 100;
        }

        public double GetSalary()
        {
            return 1000 + GetBonus();
        }

        public double GetHRA()
        {
            return 500;
        }
    }
}
