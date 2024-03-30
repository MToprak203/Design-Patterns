// Product class
class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine($"Dough: {Dough}");
        Console.WriteLine($"Sauce: {Sauce}");
        Console.WriteLine($"Topping: {Topping}");
    }
}

// Abstract builder interface
interface IPizzaBuilder
{
    void BuildDough();
    void BuildSauce();
    void BuildTopping();
    Pizza GetPizza();
}

// Concrete builder
class HawaiianPizzaBuilder : IPizzaBuilder
{
    private Pizza pizza = new Pizza();

    public void BuildDough()
    {
        pizza.Dough = "Pan crust";
    }

    public void BuildSauce()
    {
        pizza.Sauce = "Tomato sauce";
    }

    public void BuildTopping()
    {
        pizza.Topping = "Ham, Pineapple, Cheese";
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}

// Director class
class PizzaDirector
{
    public void Construct(IPizzaBuilder pizzaBuilder)
    {
        pizzaBuilder.BuildDough();
        pizzaBuilder.BuildSauce();
        pizzaBuilder.BuildTopping();
    }
}