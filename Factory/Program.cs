// Using specific factory classes
AnimalFactory dogFactory = new DogFactory();
IAnimal dog = dogFactory.CreateAnimal();
dog.Speak();  // Output: Woof!

AnimalFactory catFactory = new CatFactory();
IAnimal cat = catFactory.CreateAnimal();
cat.Speak();  // Output: Meow!

// Using flexible factory
FlexibleAnimalFactory flexibleFactory = new FlexibleAnimalFactory();
IAnimal dog2 = flexibleFactory.CreateAnimal("dog");
dog2.Speak();  // Output: Woof!

IAnimal cat2 = flexibleFactory.CreateAnimal("cat");
cat2.Speak();  // Output: Meow!