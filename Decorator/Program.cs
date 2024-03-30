// Create a basic car
ICar basicCar = new BasicCar();
Console.WriteLine("Basic Car:");
Console.WriteLine($"Description: {basicCar.GetDescription()}");
Console.WriteLine($"Cost: {basicCar.GetCost()}");

// Add a sports package to the basic car
ICar sportsCar = new SportsPackage(basicCar);
Console.WriteLine("\nSports Car:");
Console.WriteLine($"Description: {sportsCar.GetDescription()}");
Console.WriteLine($"Cost: {sportsCar.GetCost()}");

// Add a luxury package to the sports car
ICar luxurySportsCar = new LuxuryPackage(sportsCar);
Console.WriteLine("\nLuxury Sports Car:");
Console.WriteLine($"Description: {luxurySportsCar.GetDescription()}");
Console.WriteLine($"Cost: {luxurySportsCar.GetCost()}");

Console.ReadKey();