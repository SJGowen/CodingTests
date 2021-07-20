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
            engine.Add("A", 1);
            engine.Add("B", 1);
            engine.Add("C", 1);
            var total = engine.CalculateTotal();
            Assert.Equal(100, total);
        }
    }
}
