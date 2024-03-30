// Business Logic Layer
public class BusinessLogicLayer
{
    private readonly DataAccessLayer _dal;

    public BusinessLogicLayer()
    {
        _dal = new DataAccessLayer();
    }

    public string GetData()
    {
        // Perform business logic operations
        // For simplicity, let's assume we're just retrieving data from Data Access Layer
        return _dal.GetDataFromDatabase();
    }
}

// Data Access Layer
public class DataAccessLayer
{
    public string GetDataFromDatabase()
    {
        // In a real scenario, this method would connect to a database and retrieve data
        return "Data retrieved from database.";
    }
}