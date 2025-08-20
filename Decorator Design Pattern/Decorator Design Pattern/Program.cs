// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Ipizza pizza = new Margherita();
pizza = new Olives(pizza);
pizza = new Capcicum(pizza);
pizza = new Mozerrela(pizza);
pizza = new CheeseBurst(pizza);

Console.WriteLine(pizza.GetDesc());
Console.WriteLine(pizza.GetPrice());



public interface Ipizza
{
    public string GetDesc();
    public double GetPrice();
    public Ipizza GetClone();
}


//Base Option

public class Margherita : Ipizza
{
    public Margherita()
    {

    }
    public string GetDesc()
    {
        return "Margherita ";
    }

    public double GetPrice()
    {
        return 100;
    }

    public Ipizza GetClone()
    {
        return new Margherita();
    }
}


// this can be base or topping
public class CheeseBurst : Ipizza
{
    protected Ipizza Pizza;
    public CheeseBurst(Ipizza pizza)
    {
        Pizza = pizza;
    }
    public string GetDesc()
    {
        return Pizza.GetDesc() + "Cheese Burst Added ";
    }

    public double GetPrice()
    {
        return Pizza.GetPrice() + 30;
    }

    public Ipizza GetClone()
    {
        return new CheeseBurst(Pizza.GetClone());
    }
}

//Topping

public class Olives : Ipizza
{
    protected Ipizza Pizza;
    public Olives(Ipizza pizza)
    {
        Pizza = pizza;
    }
    public string GetDesc()
    {
        return Pizza.GetDesc() + "Olives Added ";
    }

    public double GetPrice()
    {
        return Pizza.GetPrice() + 30;
    }

    public Ipizza GetClone()
    {
        return new CheeseBurst(Pizza.GetClone());
    }
}

public class Capcicum : Ipizza
{
    protected Ipizza Pizza;
    public Capcicum(Ipizza pizza)
    {
        Pizza = pizza;
    }
    public string GetDesc()
    {
        return Pizza.GetDesc() + "Capcicum Added ";
    }

    public double GetPrice()
    {
        return Pizza.GetPrice() + 30;
    }

    public Ipizza GetClone()
    {
        return new CheeseBurst(Pizza.GetClone());
    }
}

public class Mozerrela : Ipizza
{
    protected Ipizza Pizza;
    public Mozerrela(Ipizza pizza)
    {
        Pizza = pizza;
    }

    public string GetDesc()
    {
        return Pizza.GetDesc() + "Mozerella Added " ;
    }

    public double GetPrice()
    {
        return Pizza.GetPrice() + 5;
    }

    public Ipizza GetClone()
    {
        return new CheeseBurst(Pizza.GetClone());
    }
}
