IUserRepository userRepository = new UserRepository();

// Adding a user
User newUser = new User { Id = 1, Name = "John Doe" };
userRepository.Add(newUser);

// Getting a user
User retrievedUser = userRepository.GetById(1);
Console.WriteLine($"Retrieved user: {retrievedUser.Name}");

// Updating a user
retrievedUser.Name = "Jane Doe";
userRepository.Update(retrievedUser);
Console.WriteLine($"Updated user: {retrievedUser.Name}");

// Deleting a user
userRepository.Delete(retrievedUser);
Console.WriteLine($"User deleted");
