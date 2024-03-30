// Component interface
public interface ICar
{
    string GetDescription();
    double GetCost();
}

// Concrete Component
public class BasicCar : ICar
{
    public string GetDescription()
    {
        return "Basic Car";
    }

    public double GetCost()
    {
        return 20000.0;
    }
}

// Decorator
public abstract class CarDecorator : ICar
{
    protected ICar decoratedCar;

    public CarDecorator(ICar decoratedCar)
    {
        this.decoratedCar = decoratedCar;
    }

    public virtual string GetDescription()
    {
        return decoratedCar.GetDescription();
    }

    public virtual double GetCost()
    {
        return decoratedCar.GetCost();
    }
}

// Concrete Decorator 1
public class SportsPackage : CarDecorator
{
    public SportsPackage(ICar decoratedCar) : base(decoratedCar) { }

    public override string GetDescription()
    {
        return $"{decoratedCar.GetDescription()}, Sports Package";
    }

    public override double GetCost()
    {
        return decoratedCar.GetCost() + 5000.0;
    }
}

// Concrete Decorator 2
public class LuxuryPackage : CarDecorator
{
    public LuxuryPackage(ICar decoratedCar) : base(decoratedCar) { }

    public override string GetDescription()
    {
        return $"{decoratedCar.GetDescription()}, Luxury Package";
    }

    public override double GetCost()
    {
        return decoratedCar.GetCost() + 10000.0;
    }
}