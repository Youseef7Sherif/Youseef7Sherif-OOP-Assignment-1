namespace BuilderPattern;

public class InvoiceBuilder
{
    private Guid? _invoiceId;
    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private Address? _billingAddress;
    private Address? _shippingAddress;

    private OrderInfo? _orderInfo;

    public InvoiceBuilder SetInvoiceId(Guid invoiceId)
    {
        _invoiceId = invoiceId;
        return this;
    }

    public InvoiceBuilder SetCustomerName(string customerName)
    {
        _customerName = customerName;
        return this;
    }

    public InvoiceBuilder SetCustomerEmail(string customerEmail)
    {
        _customerEmail = customerEmail;
        return this;
    }

    public InvoiceBuilder SetCustomerPhone(string customerPhone)
    {
        _customerPhone = customerPhone;
        return this;
    }

    public InvoiceBuilder SetBillingAddress(Address address)
    {
        _billingAddress = address;
        return this;
    }

    public InvoiceBuilder SetShippingAddress(Address address)
    {
        _shippingAddress = address;
        return this;
    }

    public InvoiceBuilder SetOrderInfo(OrderInfo orderInfo)
    {
        _orderInfo = orderInfo;
        return this;
    }

    public Invoice Build()
    {
        ValidateRequiredProperties();

        return new Invoice(
            _invoiceId!.Value,
            _customerName!,
            _customerEmail!,
            _customerPhone,
            _billingAddress!,
            _shippingAddress!,
            _orderInfo!);
    }

    private void ValidateRequiredProperties()
    {
        if (!_invoiceId.HasValue)
            throw new InvalidOperationException("InvoiceId is required.");

        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException("CustomerName is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException("CustomerEmail is required.");

        if (_billingAddress == null)
            throw new InvalidOperationException("BillingAddress is required.");

        if (_shippingAddress == null)
            throw new InvalidOperationException("ShippingAddress is required.");

        if (_orderInfo == null)
            throw new InvalidOperationException("OrderInfo is required.");
    }
}