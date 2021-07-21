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
            engine.Order("A", 1);
            engine.Order("B", 1);
            engine.Order("C", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(100, total);
        }

        [Fact]
        public void ScenarioB()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Order("A", 5);
            engine.Order("B", 5);
            engine.Order("C", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(370, total);
        }

        [Fact]
        public void ScenarioC()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Order("A", 3);
            engine.Order("B", 5);
            engine.Order("C", 1);
            engine.Order("D", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(280, total);
        }

        [Fact]
        public void MultipleCombiDiscountCanApply()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            engine.Order("A", 3);
            engine.Order("B", 5);
            engine.Order("C", 2);
            engine.Order("D", 3);
            var total = engine.CalculateTotal();
            Assert.Equal(325, total);
        }

        [Fact]
        public void CannotOrderUnstockedItem()
        {
            var engine = new PromotionEngineV1();
            StockWithTestData(engine);
            var caughtException = Assert.Throws<KeyNotFoundException>(() => engine.Order("E", 3));
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
