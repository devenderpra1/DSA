using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Simple_Factory
{
    public class PermanentEmployeeManager : IEmployeeManager
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
            return 200;
        }

        public double GetMedicalAllowance()
        {
            return 200;
        }
    }
}
