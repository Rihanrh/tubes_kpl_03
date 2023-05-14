using System;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    ConfirmationPayment,
    InProgress,
    Completed,
    OrderDone
}

public class OrderManager
{
    private static readonly Order[] Orders =
    {
        new Order { OrderId = 1, CustomerName = "Putri Auliya", Status = OrderStatus.ConfirmationPayment },
        new Order { OrderId = 2, CustomerName = "Auliya", Status = OrderStatus.InProgress },
        new Order { OrderId = 3, CustomerName = "Rahmah", Status = OrderStatus.OrderDone },
        new Order { OrderId = 4, CustomerName = "Auliya Rahmah", Status = OrderStatus.Completed },
        new Order { OrderId = 5, CustomerName = "Putri Rahmah", Status = OrderStatus.ConfirmationPayment}
    };

    public void DisplayOrders()
    {
        Console.WriteLine("Current Orders:");

        int queueNumber = 1;

        foreach (Order order in Orders)
        {
            if (order.Status != OrderStatus.OrderDone)
            {
                Console.WriteLine($"#{queueNumber} - Order ID: {order.OrderId}, Customer Name: {order.CustomerName}, Status: {order.Status}");
                queueNumber++;
            }
        }

        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        OrderManager manager = new OrderManager();
        manager.DisplayOrders();
    }
}
