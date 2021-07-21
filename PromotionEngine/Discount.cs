namespace PromotionEngine
{
    internal class Discount
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Discount(string sku, int quantity, decimal price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}