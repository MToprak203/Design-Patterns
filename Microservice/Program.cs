// Initialize services
var productService = new ProductService();
var paymentService = new PaymentService();
var notificationService = new NotificationService();

var orderService = new OrderService(productService, paymentService, notificationService);

// Simulate a user placing an order
var order = new Order
{
    Id = 1,
    ProductId = 1,
    Quantity = 3,
    TotalPrice = 150,
    UserId = 123
};

// Place the order
await orderService.PlaceOrderAsync(order);