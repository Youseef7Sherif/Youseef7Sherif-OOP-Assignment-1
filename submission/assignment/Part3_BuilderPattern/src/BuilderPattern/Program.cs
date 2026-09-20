namespace BuilderPattern;

public class Program
{
    static void Main(string[] args)
    {
        var billingAddress = new AddressBuilder()
            .SetStreet("123 Main Street")
            .SetCity("Cairo")
            .SetState("Cairo")
            .SetZipCode("11511")
            .SetCountry("Egypt")
            .Build();

        var shippingAddress = new AddressBuilder()
            .SetStreet("456 Second Street")
            .SetCity("Giza")
            .SetState("Giza")
            .SetZipCode("12511")
            .SetCountry("Egypt")
            .Build();

        var orderInfo = new OrderBuilder()
            .SetOrderDate(DateTime.Today)
            .SetPaymentMethod("Credit Card")
            .SetCurrency("EGP")
            .SetSubTotal(5000)
            .SetDiscountAmount(500)
            .SetTaxAmount(450)
            .SetTotalAmount(4950)
            .Build();

        var invoice = new InvoiceBuilder()
            .SetInvoiceId(Guid.NewGuid())
            .SetCustomerName("Youssef Mohamed")
            .SetCustomerEmail("youssef@gmail.com")
            .SetCustomerPhone("01000000000")
            .SetBillingAddress(billingAddress)
            .SetShippingAddress(shippingAddress)
            .SetOrderInfo(orderInfo)
            .Build();

        Console.WriteLine($"Customer: {invoice.CustomerName}");
        Console.WriteLine($"Email: {invoice.CustomerEmail}");

        Console.WriteLine(
            $"Billing Address: {invoice.BillingAddress.City}, " +
            $"{invoice.BillingAddress.Country}");

        Console.WriteLine(
            $"Shipping Address: {invoice.ShippingAddress.City}, " +
            $"{invoice.ShippingAddress.Country}");

        Console.WriteLine($"Payment Method: {invoice.OrderInfo.PaymentMethod}");
        Console.WriteLine($"Currency: {invoice.OrderInfo.Currency}");
        Console.WriteLine($"SubTotal: {invoice.OrderInfo.SubTotal}");
        Console.WriteLine($"Discount: {invoice.OrderInfo.DiscountAmount}");
        Console.WriteLine($"Tax: {invoice.OrderInfo.TaxAmount}");
        Console.WriteLine($"Total: {invoice.OrderInfo.TotalAmount}");
    }
}