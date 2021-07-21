using PromotionEngine;
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

        private void StockWithTestData(PromotionEngineV1 engine)
        {
            engine.AddStock("A", 50m);
            engine.AddStock("B", 30m);
            engine.AddStock("C", 20m);
            engine.AddStock("D", 15m);
        }
    }
}
