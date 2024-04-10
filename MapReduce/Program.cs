// Sample sales transactions
var transactions = new List<SalesTransaction>
        {
            new SalesTransaction { ProductCategory = "Electronics", Amount = 1000.50 },
            new SalesTransaction { ProductCategory = "Clothing", Amount = 500.75 },
            new SalesTransaction { ProductCategory = "Electronics", Amount = 750.25 },
            new SalesTransaction { ProductCategory = "Books", Amount = 300.00 },
            new SalesTransaction { ProductCategory = "Clothing", Amount = 250.50 },
            new SalesTransaction { ProductCategory = "Electronics", Amount = 1200.75 }
        };

// Map phase
var mappedResults = MapReduce.Map(transactions);

// Shuffle and group by product category
var groupedResults = mappedResults.GroupBy(pair => pair.Key, pair => pair.Value);

// Reduce phase
var reducedResults = MapReduce.Reduce(groupedResults);

// Output total sales revenue for each product category
foreach (var result in reducedResults)
{
    Console.WriteLine($"Product Category: {result.Key}, Total Sales Revenue: ${result.Value}");
}