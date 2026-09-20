namespace BuilderPattern;

public class InvoiceBuilder
{
    private Guid? _invoiceId;
    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private string? _billingStreet;
    private string? _billingCity;
    private string? _billingState;
    private string? _billingZipCode;
    private string? _billingCountry;

    private string? _shippingStreet;
    private string? _shippingCity;
    private string? _shippingState;
    private string? _shippingZipCode;
    private string? _shippingCountry;

    private DateTime? _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private decimal? _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal? _totalAmount;

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

    public InvoiceBuilder SetBillingAddress(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        _billingStreet = street;
        _billingCity = city;
        _billingState = state;
        _billingZipCode = zipCode;
        _billingCountry = country;

        return this;
    }

    public InvoiceBuilder SetShippingAddress(
        string street,
        string city,
        string state,
        string zipCode,
        string country)
    {
        _shippingStreet = street;
        _shippingCity = city;
        _shippingState = state;
        _shippingZipCode = zipCode;
        _shippingCountry = country;

        return this;
    }

    public InvoiceBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public InvoiceBuilder SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public InvoiceBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public InvoiceBuilder SetSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public InvoiceBuilder SetDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public InvoiceBuilder SetTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public InvoiceBuilder SetTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
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
            _billingStreet!,
            _billingCity!,
            _billingState!,
            _billingZipCode!,
            _billingCountry!,
            _shippingStreet!,
            _shippingCity!,
            _shippingState!,
            _shippingZipCode!,
            _shippingCountry!,
            _orderDate!.Value,
            _paymentMethod!,
            _currency!,
            _subTotal!.Value,
            _discountAmount,
            _taxAmount,
            _totalAmount!.Value);
    }

    private void ValidateRequiredProperties()
    {
        if (!_invoiceId.HasValue)
            throw new InvalidOperationException("InvoiceId is required.");

        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException("CustomerName is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException("CustomerEmail is required.");

        if (string.IsNullOrWhiteSpace(_billingStreet) ||
            string.IsNullOrWhiteSpace(_billingCity) ||
            string.IsNullOrWhiteSpace(_billingState) ||
            string.IsNullOrWhiteSpace(_billingZipCode) ||
            string.IsNullOrWhiteSpace(_billingCountry))
        {
            throw new InvalidOperationException("Complete billing address is required.");
        }

        if (string.IsNullOrWhiteSpace(_shippingStreet) ||
            string.IsNullOrWhiteSpace(_shippingCity) ||
            string.IsNullOrWhiteSpace(_shippingState) ||
            string.IsNullOrWhiteSpace(_shippingZipCode) ||
            string.IsNullOrWhiteSpace(_shippingCountry))
        {
            throw new InvalidOperationException("Complete shipping address is required.");
        }

        if (!_orderDate.HasValue)
            throw new InvalidOperationException("OrderDate is required.");

        if (string.IsNullOrWhiteSpace(_paymentMethod))
            throw new InvalidOperationException("PaymentMethod is required.");

        if (string.IsNullOrWhiteSpace(_currency))
            throw new InvalidOperationException("Currency is required.");

        if (!_subTotal.HasValue)
            throw new InvalidOperationException("SubTotal is required.");

        if (!_totalAmount.HasValue)
            throw new InvalidOperationException("TotalAmount is required.");
    }
}