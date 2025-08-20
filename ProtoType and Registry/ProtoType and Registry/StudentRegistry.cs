using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType_and_Registry
{
    public class StudentRegistry
    {
        public StudentRegistry()
        {
            register = new Dictionary<string, IProtoType<Student>>();
        }

        Dictionary<string, IProtoType<Student>> register;

        public void Register(string id, IProtoType<Student> protoType)
        {
            register.Add(id, protoType);
        }

        public IProtoType<Student> GetStudent(string id)
        {
            if (register.TryGetValue(id, out IProtoType<Student> student))
            {
                return student.GetCopy();
            }
            return null;
        }
    }

    public interface IProtoType<T>
    {
        public T GetCopy();
    }
}
