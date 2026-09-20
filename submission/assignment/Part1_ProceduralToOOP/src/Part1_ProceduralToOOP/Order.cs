namespace Part1_ProceduralToOOP;

public class Order
{
    public Guid Id { get; }
    public Customer Customer { get; }
    private List<OrderLine> _orderLines=new List<OrderLine>();
    public IReadOnlyList<OrderLine> OrderLines => _orderLines.AsReadOnly();
    public decimal Total { get; private set; }
    public bool IsPaid { get; private set; }
    public Order(Customer customer)
    {
        if (customer == null)
        {
            throw new ArgumentNullException(nameof(customer));
        }
        Id = Guid.NewGuid();
        Customer = customer;
        IsPaid = false;
    }

    public void AddOrderLine(Product product, int quantity)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be a positive integer.");
        }
        product.UpdateStockRemove(quantity);
        var orderLine = new OrderLine(product, quantity);
        _orderLines.Add(orderLine);
        Total += orderLine.TotalPrice;
    }

    public bool IsCustomerVipToMakeADiscount()
    {
        return Customer.IsVip;
    }
    public void PrintOrderDetails()
    {
        Console.WriteLine($"Order ID: {Id}");
        Console.WriteLine($"Customer: {Customer.Name} (Email: {Customer.Email}, Phone: {Customer.PhoneNumber}, City: {Customer.City})");
        Console.WriteLine("Order Lines:");
        foreach (var orderLine in _orderLines)
        {
            Console.WriteLine($"- Product: {orderLine.Product.Name}, Quantity: {orderLine.Quantity}, Total Price: {orderLine.TotalPrice:C}");
        }
        if (IsCustomerVipToMakeADiscount())
        {
            Console.WriteLine("Customer is VIP. A discount will be applied.");
            var finalTotal = Total * 0.9m;

            Console.WriteLine($"Total Order Price: {finalTotal:C}");
        }
        else
        {
            Console.WriteLine($"Total Order Price: {Total:C}");
        }
    }
    public void MarkAsPaid()
    {
        if (_orderLines.Count == 0)
        {
            throw new InvalidOperationException("Cannot pay an empty order.");
        }

        IsPaid = true;
    }

}

