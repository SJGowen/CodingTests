using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionEngineV1
    {
        Queue<OrderLines> orderLines = new Queue<OrderLines>();

        public void Add(string itemSku, int quantity)
        {
            throw new NotImplementedException();
        }

        public object CalculateTotal()
        {
            throw new NotImplementedException();
        }
    }
}
