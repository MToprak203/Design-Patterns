// Adaptee - The incompatible class
class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adaptee's specific request");
    }
}

// Target - The interface expected by the client
interface ITarget
{
    void Request();
}

// Adapter - Adapts the Adaptee to the Target interface
class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}

// Client code
class Client
{
    public void MakeRequest(ITarget target)
    {
        target.Request();
    }
}