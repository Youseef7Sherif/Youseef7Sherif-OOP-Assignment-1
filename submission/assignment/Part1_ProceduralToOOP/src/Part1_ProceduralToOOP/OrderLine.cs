namespace Part1_ProceduralToOOP;
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; private set; }

        public OrderLine(Product product, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be a positive integer.");
            }
            Product = product;
            Quantity = quantity;
        }
        public decimal TotalPrice => Product.Price * Quantity;


    }

