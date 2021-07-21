using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineTests
{
    public class EngineTests
    {
        [Fact]
        public void ScenarioA()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Add("A", 1);
            engine.Add("B", 1);
            engine.Add("C", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(100, total);
        }

        [Fact]
        public void ScenarioB()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Add("A", 5);
            engine.Add("B", 5);
            engine.Add("C", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(370, total);
        }

        [Fact]
        public void ScenarioC()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Add("A", 3);
            engine.Add("B", 5);
            engine.Add("C", 1);
            engine.Add("D", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(280, total);
        }

        [Fact]
        public void CannotOrderUnstockedItem()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            var caughtException = Assert.Throws<KeyNotFoundException>(() => engine.Add("E", 3));
            Assert.Equal("You can only order items in the Catalogue!", caughtException.Message);
        }

        private void StockWithTestData(PromotionEngineV1 engine)
        {
            engine.AddStock("A", 50m);
            engine.AddStock("B", 30m);
            engine.AddStock("C", 20m);
            engine.AddStock("D", 15m);
            engine.AddDiscount("A", 3, 20m);
            engine.AddDiscount("B", 2, 15m);
            engine.AddDiscount("C", 1, "D", 1, 5m);
        }
    }
}
