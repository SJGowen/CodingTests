namespace PromotionEngine
{
    internal class CombiDiscount : Discount
    {
        public string Sku1 { get; set; }
        public int Quantity1 { get; set; }
        public string Sku2 { get; set; }
        public int Quantity2 { get; set; }

        public CombiDiscount(string sku1, int quantity1, string sku2, int quantity2, decimal price)
        {
            Sku1 = sku1;
            Quantity1 = quantity1;
            Sku2 = sku2;
            Quantity2 = quantity2;
            Price = price;
        }
    }
}