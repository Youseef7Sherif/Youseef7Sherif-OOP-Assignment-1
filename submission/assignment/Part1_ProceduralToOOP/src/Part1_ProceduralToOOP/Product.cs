namespace Part1_ProceduralToOOP;

public class Product
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public int StockQuantity { get; private set; }

    public Product(string name, decimal price, string description, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(description));
        }
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be zero or negative.");
        }
        if (stockQuantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stockQuantity), "Stock quantity cannot be negative.");
        }
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        StockQuantity = stockQuantity;
    }

    public void UpdateStockAdd(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        }
        StockQuantity += quantity;
    }

    public void UpdateStockRemove(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        }
        if (quantity > StockQuantity)
        {
            throw new InvalidOperationException("Cannot remove more stock than available.");
        }
        StockQuantity -= quantity;
    }
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be zero or negative.");
        }
        Price = newPrice;
    }
    public void UpdateDescription(string newDescription)
    {
        if (string.IsNullOrWhiteSpace(newDescription))
        {
            throw new ArgumentException("Description cannot be null or empty.", nameof(newDescription));
        }
        Description = newDescription;
    }
}
