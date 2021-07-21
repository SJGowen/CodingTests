namespace PromotionEngine
{
    internal class QuantityDiscount : Discount
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public QuantityDiscount(string sku, int quantity, decimal price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}