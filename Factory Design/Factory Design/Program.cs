// See https://aka.ms/new-console-template for more information
using Factory_Design;
using Factory_Design.Factory_Design_Pattern;
using Factory_Design.Simple_Factory;

Console.WriteLine("Hello, World!");

var newEmployee = new Employee();


//Bifurcation based on Employee Type
EmployeeFactory employeeFactory = new EmployeeFactory();
var employeeManager = employeeFactory.CreateEmployee(1);
newEmployee.Bonus = employeeManager.GetBonus();
newEmployee.Salary = employeeManager.GetSalary();


//Bifurcation based on EmplyeeType and Selective Applicability
BaseEmployeeFactory empFactory =
                    new EmployeeManagerFactory().CreateFactory(newEmployee);
empFactory.ApplySalary();