namespace PromotionEngine
{
    internal class StockItem
    {
        public string sku { get; set; }
        public decimal unitPrice { get; set; }

        public StockItem(string sku, decimal unitPrice)
        {
            this.sku = sku;
            this.unitPrice = unitPrice;
        }
    }
}