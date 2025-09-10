// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

Type type = typeof(NewAttributes);
var constructor = type.GetConstructors();


var name = typeof(Name);
var attriutes = Attribute.GetCustomAttributes(name, typeof(NewAttributes));


Console.WriteLine(attriutes);


[NewAttributes(1,"First Class")]
public class Name
{
    public Name(string name)
    {
        this._Name = name;
    }
    public string _Name;
}

public class NewAttributes : Attribute
{
    public NewAttributes(int Srno, string Name)
    {
        this.MyProperty = Srno;
        this.MyProperty2 = Name;
    }

    public int MyProperty { get; set; }

    public string MyProperty2 { get; set; }
}

