using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        List<StockItem> stockItems = new List<StockItem>();
        List<Discount> discounts = new List<Discount>();
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
                totalBill += stockItems.FirstOrDefault(s => s.Sku == orderLine.ItemSku).UnitPrice * orderLine.Quantity;
            }

            return totalBill;
        }

        public void AddStock(string sku, decimal unitPrice)
        {
            stockItems.Add(new StockItem(sku, unitPrice));
        }

        public void AddDiscount(string sku, int quantity, decimal price)
        {
            discounts.Add(new Discount(sku, quantity, price));
        }
    }
}
