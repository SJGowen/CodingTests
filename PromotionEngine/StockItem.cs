namespace PromotionEngine
{
    internal class StockItem
    {
        public string Sku { get; set; }
        public decimal UnitPrice { get; set; }

        public StockItem(string sku, decimal unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}