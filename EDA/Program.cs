OrderService orderService = new OrderService();
InventoryService inventoryService = new InventoryService();
NotificationService notificationService = new NotificationService();
LoggingService loggingService = new LoggingService();

// Subscribe services to events
orderService.OrderPlaced += inventoryService.HandleOrderPlaced;
orderService.PaymentFailed += loggingService.LogPaymentFailed;
orderService.OrderFulfilled += notificationService.HandleOrderFulfilled;

// Simulate order placement
orderService.PlaceOrder("123456", "Laptop", 2);