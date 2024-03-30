// Define a simple entity class
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// Define a generic repository interface
public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
}

// Implement the IRepository interface in ProductRepository
public class ProductRepository : IRepository<Product>
{
    // This is a simple implementation using in-memory storage for demonstration purposes
    private List<Product> products = new List<Product>();

    public void Add(Product product)
    {
        products.Add(product);
    }

    public void Update(Product product)
    {
        // For simplicity, we'll assume the product is already in the list
        // In a real-world scenario, you would typically query the database to update the entity
    }

    public void Delete(Product product)
    {
        products.Remove(product);
    }

    public Product GetById(int id)
    {
        return products.Find(p => p.Id == id);
    }

    public IEnumerable<Product> GetAll()
    {
        return products;
    }
}

// Implement the Unit of Work pattern
public class UnitOfWork : IDisposable
{
    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
    private bool _disposed;

    public IRepository<Product> ProductRepository => GetRepository<Product>();

    public void SaveChanges()
    {
        // In a real-world scenario, this method would commit the transaction to the database
        Console.WriteLine("Changes saved to the database.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
            }

            _disposed = true;
        }
    }

    private IRepository<T> GetRepository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new ProductRepository(); // In a real-world scenario, you might use dependency injection here
        }
        return (IRepository<T>)_repositories[type];
    }
}