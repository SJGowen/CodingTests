using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        readonly List<StockItem> stockItems = new();
        readonly List<QuantityDiscount> quantityDiscounts = new();
        readonly List<CombiDiscount> combiDiscounts = new();
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

                var quantityDiscs = quantityDiscounts.Where(d => d.Sku == orderLine.ItemSku && d.Quantity <= orderLine.Quantity);
                if (quantityDiscs.Any())
                {
                    totalDiscount += quantityDiscs.FirstOrDefault().Price * (orderLine.Quantity / quantityDiscs.FirstOrDefault().Quantity);
                } 
            }

            foreach (var combiDiscount in combiDiscounts)
            {
                var combiDiscs = orderLines.Where(l => l.ItemSku == combiDiscount.Sku1 && l.Quantity >= combiDiscount.Quantity1);
                if (combiDiscs.Any())
                {
                    combiDiscs = orderLines.Where(l => l.ItemSku == combiDiscount.Sku2 && l.Quantity >= combiDiscount.Quantity2);
                    if (combiDiscs.Any())
                    {
                        totalDiscount += combiDiscount.Price;
                    }
                }
            }

            return totalBill - totalDiscount;
        }

        public void AddStock(string sku, decimal unitPrice)
        {
            stockItems.Add(new StockItem(sku, unitPrice));
        }

        public void AddDiscount(string sku1, int quantity1, string sku2, int quantity2, decimal price)
        {
            combiDiscounts.Add(new CombiDiscount(sku1, quantity1, sku2, quantity2, price));
        }

        public void AddDiscount(string sku, int quantity, decimal price)
        {
            quantityDiscounts.Add(new QuantityDiscount(sku, quantity, price));
        }
    }
}
