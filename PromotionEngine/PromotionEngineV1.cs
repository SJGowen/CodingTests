using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        readonly List<StockItem> stockItems = new();
        readonly List<Discount> discounts = new();
        readonly Queue<OrderLine> orderLines = new();

        public void Add(string itemSku, int quantity)
        {
            orderLines.Enqueue(new OrderLine(itemSku, quantity));
        }

        public decimal CalculateTotal()
        {
            var totalBill = 0m;
            var totalDiscount = 0m;
            foreach (var orderLine in orderLines)
            {
                totalBill += stockItems.FirstOrDefault(s => s.Sku == orderLine.ItemSku).UnitPrice * orderLine.Quantity;
                var quantityDiscounts = discounts.Where(d => d.Sku == orderLine.ItemSku);
                if (quantityDiscounts.Any())
                    totalDiscount += quantityDiscounts.FirstOrDefault().Price * (orderLine.Quantity / quantityDiscounts.FirstOrDefault().Quantity);
            }

            return totalBill - totalDiscount;
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
