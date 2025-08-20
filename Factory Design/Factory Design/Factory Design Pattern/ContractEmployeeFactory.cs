using Factory_Design.Simple_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Factory_Design_Pattern
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {

        public ContractEmployeeFactory(Employee employee) : base(employee)
        {

        }

        public override IEmployeeManager Create()
        {
            ContractEmployeeManager employeeManager = new ContractEmployeeManager();
            Employee.HRA = employeeManager.GetHRA();
            return employeeManager ;
        }
    }
}