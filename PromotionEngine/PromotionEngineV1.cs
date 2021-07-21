using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        List<StockItems> stockItems = new List<StocskItems>();
        Queue<OrderLine> orderLines = new Queue<OrderLine>();

        public void Add(string itemSku, int quantity)
        {
            orderLines.Enqueue(new OrderLine(itemSku, quantity));
        }

        public object CalculateTotal()
        {
            throw new NotImplementedException();
        }

        public void AddStock(string sku, decimal unitPrice)
        {
            stockItems.Add(new StockItems(sku, unitPrice));
        }
    }
}
