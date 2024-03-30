// Accessing the Singleton instance
Singleton singleton1 = Singleton.GetInstance();
Singleton singleton2 = Singleton.GetInstance();

// Both references should point to the same instance
Console.WriteLine(singleton1 == singleton2); // Output: True

// Calling a method on the Singleton instance
singleton1.SomeMethod(); // Output: Singleton method called.