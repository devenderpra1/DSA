// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Student Student = Student.GetBuilder().SetID(1).SetName("Devender").Build();


public class Student
{
    private Student(StudentBuilder studentBuilder)
    {
        this.Id = studentBuilder.Id;
        this.Name = studentBuilder.Name;
        this.Description = studentBuilder.Description;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public static StudentBuilder GetBuilder() // because we dont want to create student object and delegate it to builder
    {
        return new StudentBuilder();
    }

    public class StudentBuilder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public StudentBuilder SetID(int id)
        {
            this.Id = id;
            return this;
        }
        public StudentBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }
        public StudentBuilder SetDescription(string description)
        {
            this.Description = description;
            return this;
        }
        public bool Validate()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return true;
        }

        public Student Build()
        {
            if (!Validate())
            {
                throw new InvalidOperationException();
            }
            return new Student(this);
        }
    }
}