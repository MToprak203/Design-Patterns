using System.IO.Pipes;
using System.Runtime.Serialization.Formatters.Binary;

// Define the interface for the calculator service
public interface ICalculatorService
{
    int Add(int num1, int num2);
    int Subtract(int num1, int num2);
}

// Implement the calculator service interface
public class Calculator : ICalculatorService
{
    public int Add(int num1, int num2)
    {
        Console.WriteLine($"Service: Adding numbers {num1} and {num2}...");
        return num1 + num2;
    }

    public int Subtract(int num1, int num2)
    {
        Console.WriteLine($"Service: Subtracting numbers {num1} and {num2}...");
        return num1 - num2;
    }
}

// Class to host the calculator service as a server
public class CalculatorServer
{
    private NamedPipeServerStream _pipeServer;

    // Method to start the server asynchronously
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            // Create a named pipe server stream with a specified pipe name and direction
            _pipeServer = new NamedPipeServerStream("CalculatorPipe", PipeDirection.InOut);

            Console.WriteLine("Waiting for client connection...");

            // Wait asynchronously for a client to connect to the named pipe server
            await _pipeServer.WaitForConnectionAsync().WithCancellation(cancellationToken);

            Console.WriteLine("Client connected.");

            BinaryFormatter formatter = new BinaryFormatter();
            ICalculatorService calculator = new Calculator();

            // Continuously handle client requests until the client disconnects or an exception occurs
            while (_pipeServer.IsConnected && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Read the operation (addition or subtraction) requested by the client

                    // Create a byte array to store the operation character sent by the client
                    byte[] operationBuffer = new byte[1];

                    // Asynchronously read data from the named pipe server stream into the operationBuffer array
                    // Parameters:
                    //   operationBuffer: The byte array where the read data will be stored
                    //   0: The zero-based byte offset in operationBuffer at which to begin copying bytes from the pipe
                    //   1: The maximum number of bytes to read, which is 1 in this case (since we're reading only one byte)
                    int bytesRead = await _pipeServer.ReadAsync(operationBuffer, 0, 1).WithCancellation(cancellationToken);

                    // Convert the byte read from the pipe to a character and then to a string representation
                    string request = Convert.ToChar(operationBuffer[0]).ToString();

                    // Deserialize the arguments (numbers) sent by the client
                    var args = (Tuple<int, int>)formatter.Deserialize(_pipeServer);

                    // Perform the requested operation and get the result
                    int result = request switch
                    {
                        "A" => calculator.Add(args.Item1, args.Item2),
                        "S" => calculator.Subtract(args.Item1, args.Item2),
                        _ => throw new ArgumentException("Invalid operation"),
                    };

                    // Serialize the result and send it back to the client
                    formatter.Serialize(_pipeServer, result);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during request processing
                    Console.WriteLine($"Error: {ex.Message}");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during request processing
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Close the named pipe server stream
            Console.WriteLine("Server Closing.");
            _pipeServer?.Close();
        }
    }
}

// Class to interact with the calculator service as a client
public class CalculatorClient
{
    private readonly NamedPipeClientStream _pipeClient;

    // Constructor to initialize the named pipe client stream
    public CalculatorClient()
    {
        // Create a named pipe client stream with a specified server name, pipe name, and direction
        _pipeClient = new NamedPipeClientStream(".", "CalculatorPipe", PipeDirection.InOut);
    }

    // Method to asynchronously connect to the server
    public async Task ConnectAsync()
    {
        // Connect to the server asynchronously
        await _pipeClient.ConnectAsync();

        Console.WriteLine("Client connected to server.");
    }

    // Method to asynchronously send a request to the server and receive the response
    public async Task<int> SendRequestAsync(string operation, int num1, int num2)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        // Write the operation (addition or subtraction) to the named pipe client stream

        // Convert the first character of the operation string to a byte and create a byte array
        byte[] operationBytes = new byte[] { Convert.ToByte(operation[0]) };

        // Write the operation byte array to the named pipe client stream asynchronously
        // Parameters:
        //   operationBytes: The byte array containing the operation character
        //   0: The zero-based byte offset in operationBytes at which to begin copying bytes to the pipe
        //   1: The number of bytes to write, which is 1 in this case (since we're writing only one byte)
        await _pipeClient.WriteAsync(operationBytes, 0, 1);

        // Serialize the arguments (numbers) and send them to the server
        formatter.Serialize(_pipeClient, Tuple.Create(num1, num2));

        // Deserialize and return the result received from the server
        return (int)formatter.Deserialize(_pipeClient);
    }
}

public static class TaskExtensions
{
    public static async Task WithCancellation(this Task task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>();
        using (cancellationToken.Register(() => tcs.TrySetResult(true)))
        {
            if (task != await Task.WhenAny(task, tcs.Task))
            {
                throw new OperationCanceledException(cancellationToken);
            }
        }
    }

    public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource<bool>();
        using (cancellationToken.Register(() => tcs.TrySetResult(true)))
        {
            if (task != await Task.WhenAny(task, tcs.Task))
            {
                throw new OperationCanceledException(cancellationToken);
            }
        }
        return await task;
    }
}
