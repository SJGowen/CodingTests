namespace PromotionEngine
{
    public class OrderLine
    {
        public string itemSku { get; set; }
        public int quantity { get; set; }

        public OrderLine(string itemSku, int quantity)
        {
            this.itemSku = itemSku;
            this.quantity = quantity;
        }
    }
}