// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class OrderCreator
{
    private IOrderDetails _orderDetails;

    private IDispatcher _dispatcher;
    public void SendParcel()
    {
        Console.WriteLine(_orderDetails.GetOrderDetails());
        _dispatcher.SendOrder(_orderDetails.GetDeliveryDetails());
    }
}

#region OrderPlacer
interface IOrderDetails
{
    string Name { get; }
    string GetOrderDetails();
    public IAddressDetails GetDeliveryDetails();
}

public class OnlineOrder : IOrderDetails
{
    IAddressDetails _address = new Address();
    public string Name => "Online Order";

    public IAddressDetails GetDeliveryDetails()
    {
        return _address;
    }

    public string GetOrderDetails()
    {
        throw new NotImplementedException();
    }
}

public class OfflineOrder : IOrderDetails
{
    IAddressDetails _address = new Address();
    public string Name => "Offline Order";

    public IAddressDetails GetDeliveryDetails()
    {
        return _address;
    }

    public string GetOrderDetails()
    {
        throw new NotImplementedException();
    }
}
public class StoreOrder : IOrderDetails
{
    IAddressDetails _address = new Address();
    public string Name => "Store Order";

    public IAddressDetails GetDeliveryDetails()
    {
        return _address;
    }
    public string GetOrderDetails()
    {
        throw new NotImplementedException();
    }
}

#endregion

public interface IAddressDetails
{
    public int PinCode { get; }

    public string AddressDetail { get; }
}

public class Address : IAddressDetails
{
    public int PinCode { get => _Pincode; }

    private int _Pincode;
    public string AddressDetail { get => _Address; }

    private string _Address;
}

# region Dispatcher Of Parcel
interface IDispatcher
{
    bool SendOrder(IAddressDetails addressDetails);
}

public class FedEx : IDispatcher
{
    public bool SendOrder()
    {
        //Connect
        //Send Request
        //Wait for order to get placed
        throw new NotImplementedException();
    }

    bool IDispatcher.SendOrder(IAddressDetails addressDetails)
    {
        //Connect
        //Send Request
        //Wait for order to get placed
        throw new NotImplementedException();
    }
}

public class Porter : IDispatcher
{
    public bool SendOrder()
    {
        throw new NotImplementedException();
    }

    bool IDispatcher.SendOrder(IAddressDetails addressDetails)
    {
        throw new NotImplementedException();
    }
}

#endregion