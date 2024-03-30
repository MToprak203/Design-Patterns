PizzaDirector director = new PizzaDirector();
HawaiianPizzaBuilder builder = new HawaiianPizzaBuilder();

director.Construct(builder);
Pizza pizza = builder.GetPizza();

Console.WriteLine("Hawaiian Pizza:");
pizza.Display();