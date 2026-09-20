namespace BuilderPattern;

public class OrderBuilder
{
    private DateTime? _orderDate;
    private string? _paymentMethod;
    private string? _currency;
    private decimal? _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal? _totalAmount;

    public OrderBuilder SetOrderDate(DateTime orderDate)
    {
        _orderDate = orderDate;
        return this;
    }

    public OrderBuilder SetPaymentMethod(string paymentMethod)
    {
        _paymentMethod = paymentMethod;
        return this;
    }

    public OrderBuilder SetCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder SetSubTotal(decimal subTotal)
    {
        _subTotal = subTotal;
        return this;
    }

    public OrderBuilder SetDiscountAmount(decimal discountAmount)
    {
        _discountAmount = discountAmount;
        return this;
    }

    public OrderBuilder SetTaxAmount(decimal taxAmount)
    {
        _taxAmount = taxAmount;
        return this;
    }

    public OrderBuilder SetTotalAmount(decimal totalAmount)
    {
        _totalAmount = totalAmount;
        return this;
    }

    public OrderInfo Build()
    {
        ValidateRequiredProperties();

        return new OrderInfo(
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