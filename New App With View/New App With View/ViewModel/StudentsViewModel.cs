using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace New_App_With_View.ViewModel
{
    public class StudentsViewModel
    {
        Student Student;

        public string FullName { get { return Student.FName + Student.LName; } }
    }
}
