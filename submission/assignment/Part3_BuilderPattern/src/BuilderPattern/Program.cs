namespace BuilderPattern;

internal class Program
{
    static void Main(string[] args)
    {
        var invoice = new InvoiceBuilder()
            .SetInvoiceId(Guid.NewGuid())
            .SetCustomerName("Youssef Mohamed")
            .SetCustomerEmail("youssef@gmail.com")
            .SetCustomerPhone("01000000000")
            .SetBillingAddress(
                "123 Main Street",
                "Cairo",
                "Cairo",
                "11511",
                "Egypt")
            .SetShippingAddress(
                "456 Second Street",
                "Giza",
                "Giza",
                "12511",
                "Egypt")
            .SetOrderDate(DateTime.Today)
            .SetPaymentMethod("Credit Card")
            .SetCurrency("EGP")
            .SetSubTotal(5000)
            .SetDiscountAmount(500)
            .SetTaxAmount(450)
            .SetTotalAmount(4950)
            .Build();

        Console.WriteLine($"Customer: {invoice.CustomerName}");
        Console.WriteLine($"Email: {invoice.CustomerEmail}");
        Console.WriteLine($"Billing City: {invoice.BillingCity}");
        Console.WriteLine($"Shipping City: {invoice.ShippingCity}");
        Console.WriteLine($"Payment Method: {invoice.PaymentMethod}");
        Console.WriteLine($"Currency: {invoice.Currency}");
        Console.WriteLine($"SubTotal: {invoice.SubTotal}");
        Console.WriteLine($"Discount: {invoice.DiscountAmount}");
        Console.WriteLine($"Tax: {invoice.TaxAmount}");
        Console.WriteLine($"Total: {invoice.TotalAmount}");
    }
}