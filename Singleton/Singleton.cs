public class Singleton
{
    private static Singleton instance;
    private static readonly object lockObject = new object();

    // Private constructor to prevent instantiation
    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
        // Double-check locking for thread safety
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }

    // Add other methods or properties as needed
    public void SomeMethod()
    {
        Console.WriteLine("Singleton method called.");
    }
}

