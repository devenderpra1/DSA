using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class Student : INotifyCollectionChanged
    {
        public Student(string ID, string fName, string lName, bool isDocumentVerified)
        {
            _ID = ID;
            FName = fName;
            LName = lName;
            IsDocumentVerified = isDocumentVerified;

        }

        public Student(string ID, string fname, string lName)
            : this(ID, fname, lName, true)
        {

        }

        public Student(string iD)
        {
            ID = iD;
        }
        public string ID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public bool IsDocumentVerified { get; set; }

        //public void SetIDForce(string ID)
        //{
        //    _ID = ID;
        //}
        private readonly string _ID = null;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
