using Factory_Design.Simple_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Factory_Design_Pattern
{
    public abstract class BaseEmployeeFactory
    {
        protected Employee Employee;

        public BaseEmployeeFactory(Employee employee)
        {
            Employee = employee;
        }

        public Employee ApplySalary()
        {
            IEmployeeManager employeeManager = this.Create();
            Employee.Bonus = employeeManager.GetBonus();
            Employee.Salary = employeeManager.GetSalary();
            return Employee;
        }

        public abstract IEmployeeManager Create();
    }
}
