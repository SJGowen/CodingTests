namespace PromotionEngine
{
    internal class StockItems
    {
        private string sku;
        private decimal unitPrice;

        public StockItems(string sku, decimal unitPrice)
        {
            this.sku = sku;
            this.unitPrice = unitPrice;
        }
    }
}