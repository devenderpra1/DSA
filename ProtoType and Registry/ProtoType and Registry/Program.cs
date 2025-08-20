// See https://aka.ms/new-console-template for more information
using ProtoType_and_Registry;

Console.WriteLine("Hello, World!");


StudentRegistry studentRegistry = new StudentRegistry();
studentRegistry.Register("Normal Student",new Student(1, "Dev", 201));
studentRegistry.Register("Genius Student",new IntelligentStudent(1, "Dev", 201, IQ.Genius));
studentRegistry.Register("Extraordinary Student",new IntelligentStudent(1, "Dev", 201, IQ.Extraordinary));