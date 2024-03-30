// Define the User entity
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    // other properties
}

// Define the UserRepository interface
public interface IUserRepository
{
    User GetById(int id);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}

// Implement the UserRepository
public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>(); // In a real-world scenario, this would be replaced with a database context or another data source

    public User GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }

    public void Update(User user)
    {
        var existingUser = GetById(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            // update other properties as needed
        }
    }

    public void Delete(User user)
    {
        var existingUser = GetById(user.Id);
        if (existingUser != null)
        {
            _users.Remove(existingUser);
        }
    }
}
