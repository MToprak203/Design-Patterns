// Model
public class UserModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
}

// View
public class UserView
{
    public void DisplayUserDetails(string userName, string email)
    {
        Console.WriteLine($"User Name: {userName}");
        Console.WriteLine($"Email: {email}");
    }
}

// Controller
public class UserController
{
    private UserModel _model;
    private UserView _view;

    public UserController(UserModel model, UserView view)
    {
        _model = model;
        _view = view;
    }

    public void UpdateUserData(string userName, string email)
    {
        _model.UserName = userName;
        _model.Email = email;
    }

    public void DisplayUserData()
    {
        _view.DisplayUserDetails(_model.UserName, _model.Email);
    }
}