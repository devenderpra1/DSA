// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public abstract class Animal
{
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public abstract void MakeSound();
}

public class Vehicle
{
    public int NoOfWheels { get; set; }

    public virtual int GetNoOfWheels()
    {
        return NoOfWheels;
    }
}

interface IBus
{
    int NoOfWheels { get; set; }
    void GetNoOfWheels();
}

public class Bus : IBus
{
    public int NoOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void GetNoOfWheels()
    {
        throw new NotImplementedException();
    }
}

public class Bike : Vehicle
{
    public override int GetNoOfWheels()
    {
        return base.GetNoOfWheels();
    }

}

public class MotorBike : Bike
{

}