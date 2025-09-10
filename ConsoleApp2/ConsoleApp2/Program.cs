using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Animal animal = new Animal();
        }
    }

    public struct Animal
    {
        private Animal()
        {

        }
        public int Datakey;

        public string Reftype;
        
    }
}
