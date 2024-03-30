// Abstract Product
public interface IAnimal
{
    void Speak();
}

// Concrete Products
public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

// Abstract Factory
public abstract class AnimalFactory
{
    public abstract IAnimal CreateAnimal();
}

// Concrete Factory for Dog
public class DogFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

// Concrete Factory for Cat
public class CatFactory : AnimalFactory
{
    public override IAnimal CreateAnimal()
    {
        return new Cat();
    }
}

// Flexible Factory
public class FlexibleAnimalFactory
{
    public IAnimal CreateAnimal(string animalType)
    {
        switch (animalType.ToLower())
        {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                throw new ArgumentException($"Invalid animal type: {animalType}");
        }
    }
}