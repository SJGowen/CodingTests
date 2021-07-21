using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        Queue<OrderLine> orderLines = new Queue<OrderLine>();

        public void Add(string itemSku, int quantity)
        {
            orderLines.Enqueue(new OrderLine(itemSku, quantity));
        }

        public object CalculateTotal()
        {
            throw new NotImplementedException();
        }
    }
}
