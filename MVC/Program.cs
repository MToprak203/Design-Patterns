// Create Model object
UserModel model = new UserModel();

// Create View object
UserView view = new UserView();

// Create Controller object and pass the Model and View objects to it
UserController controller = new UserController(model, view);

// Update user data through the controller
controller.UpdateUserData("John Doe", "john@example.com");

// Display user data through the controller
controller.DisplayUserData();

// Output:
// User Name: John Doe
// Email: john@example.com