// Abstract Product A
interface IChair
{
    void SitOn();
}

// Concrete Product A1
class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a modern chair.");
    }
}

// Concrete Product A2
class VictorianChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a Victorian chair.");
    }
}

// Abstract Product B
interface ISofa
{
    void RelaxOn();
}

// Concrete Product B1
class ModernSofa : ISofa
{
    public void RelaxOn()
    {
        Console.WriteLine("Relaxing on a modern sofa.");
    }
}

// Concrete Product B2
class VictorianSofa : ISofa
{
    public void RelaxOn()
    {
        Console.WriteLine("Relaxing on a Victorian sofa.");
    }
}

// Abstract Factory
interface IFurnitureFactory
{
    IChair CreateChair();
    ISofa CreateSofa();
}

// Concrete Factory 1
class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ISofa CreateSofa()
    {
        return new ModernSofa();
    }
}

// Concrete Factory 2
class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ISofa CreateSofa()
    {
        return new VictorianSofa();
    }
}

class Client
{
    private readonly IFurnitureFactory _factory;

    public Client(IFurnitureFactory factory)
    {
        _factory = factory;
    }

    public void SitAndRelax()
    {
        var chair = _factory.CreateChair();
        chair.SitOn();

        var sofa = _factory.CreateSofa();
        sofa.RelaxOn();
    }
}