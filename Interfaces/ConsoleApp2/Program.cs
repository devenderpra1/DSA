using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IGeneralProperties student = new Student();
            IGeneralProperties derivedStudent = new DerivedStudent();
            IGeneralProperties collegestudent = new CollegeStudent();

            //Console.WriteLine(collegestudent.GetFullName());
            //Console.WriteLine(student.FullName());

            var castedStudent = (Student)derivedStudent;
            //var castedDerivedStudent = (DerivedStudent)student; // Upcast is not safe

            castedStudent.GetFullName();

            //castedDerivedStudent.GetFullName();

        }
    }

    interface IGeneralProperties
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName()
        {
            return FirstName + LastName;
        }
        public string GetFullName();
    }

    class Student : IGeneralProperties
    {
        public string FirstName { get => "Devender"; set => throw new NotImplementedException(); }
        public string LastName { get => "Prasad"; set => throw new NotImplementedException(); }

        public virtual string GetFullName()
        {
            return FirstName + LastName;
        }

        public string RollNumber { get { return "1234"; } }
    }

    class CollegeStudent : IGeneralProperties
    {
        public string FirstName { get => "Devender"; set => throw new NotImplementedException(); }
        public string LastName { get => "Prasad"; set => throw new NotImplementedException(); }

        public string GetFullName()
        {
            return FirstName + LastName;
        }

        public string RFID { get { return "1234"; } }
    }

    class DerivedStudent : Student
    {
        public override string GetFullName()
        {
            return "Mr." + base.GetFullName();
        }
    }
}
