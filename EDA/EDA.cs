// Define events
public class OrderPlacedEventArgs : EventArgs
{
    public string OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    // Other order details...
}

public class PaymentCompletedEventArgs : EventArgs
{
    public string OrderId { get; set; }
    public decimal Amount { get; set; }
    // Other payment details...
}

public class PaymentFailedEventArgs : EventArgs
{
    public string OrderId { get; set; }
    public string ErrorMessage { get; set; }
    // Other error details...
}

public class OrderFulfilledEventArgs : EventArgs
{
    public string OrderId { get; set; }
    // Other order details...
}

// Order Service
public class OrderService
{
    public event EventHandler<OrderPlacedEventArgs> OrderPlaced;
    public event EventHandler<PaymentCompletedEventArgs> PaymentCompleted;
    public event EventHandler<PaymentFailedEventArgs> PaymentFailed;
    public event EventHandler<OrderFulfilledEventArgs> OrderFulfilled;

    public void PlaceOrder(string orderId, string productName, int quantity)
    {
        Console.WriteLine($"Order placed for {quantity} {productName}(s).");
        OrderPlaced?.Invoke(this, new OrderPlacedEventArgs
        {
            OrderId = orderId,
            ProductName = productName,
            Quantity = quantity
        });

        // Simulate payment processing
        if (new Random().Next(0, 2) == 0)
        {
            Console.WriteLine($"Payment for order {orderId} completed.");
            PaymentCompleted?.Invoke(this, new PaymentCompletedEventArgs
            {
                OrderId = orderId,
                Amount = quantity * 10 // Assuming each product costs $10
            });

            Console.WriteLine($"Order {orderId} fulfilled.");
            OrderFulfilled?.Invoke(this, new OrderFulfilledEventArgs
            {
                OrderId = orderId
            });
        }
        else
        {
            Console.WriteLine($"Payment for order {orderId} failed.");
            PaymentFailed?.Invoke(this, new PaymentFailedEventArgs
            {
                OrderId = orderId,
                ErrorMessage = "Insufficient funds"
            });
        }
    }
}

// Inventory Service
public class InventoryService
{
    public void HandleOrderPlaced(object sender, OrderPlacedEventArgs e)
    {
        Console.WriteLine($"Checking inventory for order {e.OrderId}...");
        // Check inventory and update stock
        Console.WriteLine($"Inventory updated for order {e.OrderId}.");
    }
}

// Notification Service
public class NotificationService
{
    public void HandleOrderFulfilled(object sender, OrderFulfilledEventArgs e)
    {
        Console.WriteLine($"Sending notification for order {e.OrderId}...");
        // Send notification to customer
        Console.WriteLine($"Notification sent for order {e.OrderId}.");
    }
}

// Logging Service
public class LoggingService
{
    public void LogPaymentFailed(object sender, PaymentFailedEventArgs e)
    {
        Console.WriteLine($"Logging payment failure for order {e.OrderId}: {e.ErrorMessage}");
        // Log payment failure
    }
}