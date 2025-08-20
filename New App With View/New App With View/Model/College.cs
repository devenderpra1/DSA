using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class College : INotifyPropertyChanged
    {
        public College()
        {
            Students = new ObservableCollection<Student>();
            CreateStudent = new DelegateCommand(OnCreateStudent, CanCreateStudent);
            UpdateIsAdmin = new DelegateCommand(OnUpdateIsAdmin, CanUpdateIsAdmin);
        }

        public ObservableCollection<Student> Students;

        public string FName { get; set; }

        public string LName { get; set; }

        public string GenerateID()
        {
            if (Students.Any())
                return $"{Students.Count}";
            return "-1";
        }

        public bool IsAdmin;
        public DelegateCommand UpdateIsAdmin;
        public void OnUpdateIsAdmin(object obj)
        {
            IsAdmin = !IsAdmin;
            NotifyUI(nameof(UpdateIsAdmin));
        }
        public bool CanUpdateIsAdmin(object obj)
        {
            return true;
        }

        public DelegateCommand CreateStudent;
        public void OnCreateStudent(object obj)
        {
            Student student = new Student(this.GenerateID());
            Students.Add(student);
        }
        public bool CanCreateStudent(object obj)
        {
            if (string.IsNullOrEmpty(FName) || string.IsNullOrEmpty(LName))
                return false;
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyUI(string property)
        {
            if (property != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
