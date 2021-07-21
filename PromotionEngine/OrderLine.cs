namespace PromotionEngine
{
    public class OrderLine
    {
        private string itemSku;
        private int quantity;

        public OrderLine(string itemSku, int quantity)
        {
            this.itemSku = itemSku;
            this.quantity = quantity;
        }
    }
}