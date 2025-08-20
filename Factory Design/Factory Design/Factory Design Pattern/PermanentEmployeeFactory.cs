using Factory_Design.Simple_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design.Factory_Design_Pattern
{
    public class PermanentEmployeeFactory : BaseEmployeeFactory
    {

        public PermanentEmployeeFactory(Employee employee) : base(employee)
        {

        }

        public override IEmployeeManager Create()
        {
            PermanentEmployeeManager employeeManager = new PermanentEmployeeManager();
            Employee.HRA = employeeManager.GetHRA();
            Employee.MedicalAllowance = employeeManager.GetMedicalAllowance();
            return employeeManager;
        }
    }
}

public class Node
{
    public Node(int value)
    {
        Value = value;
    }
    public Node Right;
    public Node Left;
    public int Value;
}

public class Tree
{
    public Node CurrentHead;

    public void TreeTraversal()
    {
        while (CurrentHead.Right != null)
        {

        }
    }
}