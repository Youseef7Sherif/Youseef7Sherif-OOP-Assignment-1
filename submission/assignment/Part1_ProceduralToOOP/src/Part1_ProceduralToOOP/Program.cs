namespace Part1_ProceduralToOOP;

internal class Program
{
    static List<Customer> customers = new();
    static List<Product> products = new();
    static List<Order> orders = new();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== Order Management System =====");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Show Customers");
            Console.WriteLine("3. Add Product");
            Console.WriteLine("4. Show Products");
            Console.WriteLine("5. Create Order");
            Console.WriteLine("6. Add Product To Order");
            Console.WriteLine("7. Pay Order");
            Console.WriteLine("8. Show Order");
            Console.WriteLine("9. Show Total Sales");
            Console.WriteLine("0. Exit");

            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;

                    case "2":
                        ShowCustomers();
                        break;

                    case "3":
                        AddProduct();
                        break;

                    case "4":
                        ShowProducts();
                        break;

                    case "5":
                        CreateOrder();
                        break;

                    case "6":
                        AddProductToOrder();
                        break;

                    case "7":
                        PayOrder();
                        break;

                    case "8":
                        ShowOrder();
                        break;

                    case "9":
                        ShowTotalSales();
                        break;

                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine() ?? "";

        Console.Write("Enter city: ");
        string city = Console.ReadLine() ?? "";

        Console.Write("Is VIP? (y/n): ");
        bool isVip = Console.ReadLine()?.Trim().ToLower() == "y";

        Customer customer = new Customer(
            name,
            email,
            phoneNumber,
            city,
            isVip);

        customers.Add(customer);

        Console.WriteLine($"Customer added successfully. ID: {customer.Id}");
    }

    static void ShowCustomers()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        foreach (Customer customer in customers)
        {
            Console.WriteLine(
                $"ID: {customer.Id} | " +
                $"Name: {customer.Name} | " +
                $"Email: {customer.Email} | " +
                $"Phone: {customer.PhoneNumber} | " +
                $"City: {customer.City} | " +
                $"VIP: {customer.IsVip}");
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Enter stock quantity: ");
        int stockQuantity = int.Parse(Console.ReadLine() ?? "0");

        Product product = new Product(
            name,
            price,
            description,
            stockQuantity);

        products.Add(product);

        Console.WriteLine($"Product added successfully. ID: {product.Id}");
    }

    static void ShowProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            Console.WriteLine(
                $"ID: {product.Id} | " +
                $"Name: {product.Name} | " +
                $"Price: {product.Price:C} | " +
                $"Stock: {product.StockQuantity}");
        }
    }

    static void CreateOrder()
    {
        if (customers.Count == 0)
        {
            Console.WriteLine("No customers available.");
            return;
        }

        ShowCustomers();

        Console.Write("Enter customer ID: ");
        string input = Console.ReadLine() ?? "";

        if (!Guid.TryParse(input, out Guid customerId))
        {
            Console.WriteLine("Invalid customer ID.");
            return;
        }

        Customer? customer = customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Order order = new Order(customer);
        orders.Add(order);

        Console.WriteLine($"Order created successfully. ID: {order.Id}");
    }

    static void AddProductToOrder()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders available.");
            return;
        }

        Console.Write("Enter order ID: ");
        string input = Console.ReadLine() ?? "";

        if (!Guid.TryParse(input, out Guid orderId))
        {
            Console.WriteLine("Invalid order ID.");
            return;
        }

        Order? order = orders.FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        if (order.IsPaid)
        {
            Console.WriteLine("Cannot modify a paid order.");
            return;
        }

        ShowProducts();

        Console.Write("Enter product ID: ");
        input = Console.ReadLine() ?? "";

        if (!Guid.TryParse(input, out Guid productId))
        {
            Console.WriteLine("Invalid product ID.");
            return;
        }

        Product? product = products.FirstOrDefault(p => p.Id == productId);

        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine() ?? "0");

        order.AddOrderLine(product, quantity);

        Console.WriteLine("Product added to order successfully.");
    }

    static void PayOrder()
    {
        Console.Write("Enter order ID: ");
        string input = Console.ReadLine() ?? "";

        if (!Guid.TryParse(input, out Guid orderId))
        {
            Console.WriteLine("Invalid order ID.");
            return;
        }

        Order? order = orders.FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        order.MarkAsPaid();

        Console.WriteLine("Order paid successfully.");
    }

    static void ShowOrder()
    {
        Console.Write("Enter order ID: ");
        string input = Console.ReadLine() ?? "";

        if (!Guid.TryParse(input, out Guid orderId))
        {
            Console.WriteLine("Invalid order ID.");
            return;
        }

        Order? order = orders.FirstOrDefault(o => o.Id == orderId);

        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        order.PrintOrderDetails();
        Console.WriteLine($"Paid: {order.IsPaid}");
    }

    static void ShowTotalSales()
    {
        decimal totalSales = orders
            .Where(order => order.IsPaid)
            .Sum(order =>
                order.Customer.IsVip
                    ? order.Total * 0.9m
                    : order.Total);

        Console.WriteLine($"Total Paid Sales: {totalSales:C}");
    }
}