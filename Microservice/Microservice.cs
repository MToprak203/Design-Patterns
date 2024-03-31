// Product model
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}

// Order model
public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int UserId { get; set; }
}

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Stock = 10, Price = 50 },
            new Product { Id = 2, Name = "Product 2", Stock = 5, Price = 100 }
        };
    }

    public async Task<bool> UpdateStockAsync(Order order)
    {
        Console.WriteLine($"ProductService: Updating stock for order {order.Id}...");

        var product = _products.FirstOrDefault(p => p.Id == order.ProductId);
        if (product == null || product.Stock < order.Quantity)
        {
            Console.WriteLine($"ProductService: Failed to update stock for order {order.Id}: Insufficient stock.");
            return false; // Insufficient stock
        }

        product.Stock -= order.Quantity;
        Console.WriteLine($"ProductService: Stock updated for order {order.Id}.");
        return true;
    }
}

public class PaymentService
{
    public async Task<bool> ProcessPaymentAsync(Order order)
    {
        Console.WriteLine($"PaymentService: Processing payment for order {order.Id}...");

        // Simulate successful payment processing
        Console.WriteLine($"PaymentService: Payment processed successfully for order {order.Id}.");
        return true;
    }
}

public class NotificationService
{
    public async Task SendOrderConfirmationAsync(int userId, int orderId)
    {
        Console.WriteLine($"NotificationService: Sending order confirmation for order {orderId} to user {userId}...");

        // Simulate sending order confirmation
        Console.WriteLine($"NotificationService: Order confirmation sent for order {orderId} to user {userId}.");
    }
}


public class OrderService
{
    private readonly ProductService _productService;
    private readonly PaymentService _paymentService;
    private readonly NotificationService _notificationService;

    public OrderService(ProductService productService, PaymentService paymentService, NotificationService notificationService)
    {
        _productService = productService;
        _paymentService = paymentService;
        _notificationService = notificationService;
    }

    public async Task<Order> PlaceOrderAsync(Order order)
    {
        Console.WriteLine($"Placing order {order.Id} for product {order.ProductId}, quantity: {order.Quantity}...");

        bool stockUpdated = await _productService.UpdateStockAsync(order);
        if (!stockUpdated)
        {
            Console.WriteLine("Order failed: Insufficient stock.");
            return null;
        }

        Console.WriteLine("Stock updated.");

        bool paymentSuccessful = await _paymentService.ProcessPaymentAsync(order);
        if (!paymentSuccessful)
        {
            Console.WriteLine("Order failed: Payment processing failed.");
            return null;
        }

        Console.WriteLine("Payment processed successfully.");

        await _notificationService.SendOrderConfirmationAsync(order.UserId, order.Id);
        Console.WriteLine("Order confirmation sent.");

        Console.WriteLine("Order successfully placed.");
        return order;
    }
}

