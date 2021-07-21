namespace PromotionEngine
{
    public class OrderLine
    {
        public string ItemSku { get; set; }
        public int Quantity { get; set; }

        public OrderLine(string itemSku, int quantity)
        {
            ItemSku = itemSku;
            Quantity = quantity;
        }
    }
}