using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        List<StockItem> stockItems = new List<StockItem>();
        Queue<OrderLine> orderLines = new Queue<OrderLine>();

        public void Add(string itemSku, int quantity)
        {
            orderLines.Enqueue(new OrderLine(itemSku, quantity));
        }

        public decimal CalculateTotal()
        {
            var totalBill = 0m;
            foreach (var orderLine in orderLines)
            {
                totalBill += stockItems.FirstOrDefault(s => s.sku == orderLine.itemSku).unitPrice * orderLine.quantity;
            }

            return totalBill;
        }

        public void AddStock(string sku, decimal unitPrice)
        {
            stockItems.Add(new StockItem(sku, unitPrice));
        }
    }
}
