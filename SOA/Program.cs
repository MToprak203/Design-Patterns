// Start the calculator server
CalculatorServer server = new CalculatorServer();
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
Task serverTask = server.StartAsync(cancellationTokenSource.Token);

// Create a delay to ensure the server has started before the client attempts to connect
await Task.Delay(100);

// Create the calculator client
CalculatorClient client = new CalculatorClient();

try
{
    // Connect to the server
    await client.ConnectAsync();

    // Send requests to the server and receive responses
    int resultAdd = await client.SendRequestAsync("A", 10, 5);
    Console.WriteLine($"Result of addition: {resultAdd}");

    int resultSubtract = await client.SendRequestAsync("S", 10, 5);
    Console.WriteLine($"Result of subtraction: {resultSubtract}");

    await Task.Delay(1000);

    resultSubtract = await client.SendRequestAsync("S", 10, 5);
    Console.WriteLine($"Result of subtraction: {resultSubtract}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    cancellationTokenSource.Cancel();

    // Wait for the server to stop
    await serverTask;
}