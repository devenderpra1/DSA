using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType_and_Registry
{
    public class Student : IProtoType<Student>
    {
        public Student(int id, string name, int batch)
        {
            this.Id = id;
            this.Name = name;
            this.Batch = batch;
        }

        //for Copy Constructor
        public Student(Student otherStudent)
        {
            this.Name = otherStudent.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Batch { get; set; }

        public virtual Student GetCopy()
        {
            return new Student(this);
        }
    }

    public class IntelligentStudent : Student
    {
        public IntelligentStudent(int id, string name, int batch, IQ iQ)
            : base(id, name, batch)
        {
            this.IQ = iQ;
            this.InternalRating = SetInternalRating(iQ);
        }

        //Copy Constructor
        public IntelligentStudent(IntelligentStudent otherIntelligentStudent)
            : base(otherIntelligentStudent)
        {
            this.IQ = otherIntelligentStudent.IQ;
            this.InternalRating = SetInternalRating(otherIntelligentStudent.IQ);
        }

        private InternalRating InternalRating;

        public InternalRating SetInternalRating(IQ iQ)
        {
            switch (iQ)
            {
                case IQ.None:
                    return InternalRating.Unknown;
                case IQ.Genius:
                    return InternalRating.Level1;
                case IQ.Extraordinary:
                    return InternalRating.Level2;
                default:
                    return InternalRating.Unknown;
            }
        }

        public InternalRating GetInternalRating()
        {
            return InternalRating;
        }

        public IQ IQ { get; set; }

        public ChampionshipWon ChampionshipWon { get; set; }

        public override Student GetCopy()
        {
            return new IntelligentStudent(this);
        }
    }

    public enum InternalRating
    {
        Unknown,
        Level1,
        Level2,
    }

    public enum IQ
    {
        None,
        Genius,
        Extraordinary
    }

    public enum ChampionshipWon
    {
        None = 0,
        MathsMaster = 1,
        ScienceMaster = 2,
    }
}
