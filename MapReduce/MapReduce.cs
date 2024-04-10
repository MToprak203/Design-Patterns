// Define a class to represent a sales transaction
public class SalesTransaction
{
    public string ProductCategory { get; set; }
    public double Amount { get; set; }
}

public class MapReduce
{
    // Map function
    public static IEnumerable<KeyValuePair<string, double>> Map(List<SalesTransaction> transactions)
    {
        // Emit key-value pairs where key is product category and value is transaction amount
        foreach (var transaction in transactions)
        {
            yield return new KeyValuePair<string, double>(transaction.ProductCategory, transaction.Amount);
        }
    }

    // Reduce function
    public static Dictionary<string, double> Reduce(IEnumerable<IGrouping<string, double>> groups)
    {
        // Aggregate total sales revenue for each product category
        var result = new Dictionary<string, double>();
        foreach (var group in groups)
        {
            result[group.Key] = group.Sum();
        }
        return result;
    }
}

