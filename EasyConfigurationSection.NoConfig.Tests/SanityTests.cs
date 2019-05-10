using NUnit.Framework;

namespace EasyConfigurationSection.NoConfig.Tests
{
    public class SanityTests
    {
        [Test]
        public void TryGetSectionTest()
        {
            var success = new EasyConfiguration().TryGetSection("any", out SanityTests _);
            Assert.False(success);
        }

        [Test]
        public void GetSectionTest()
        {
            Assert.Throws<EasyConfigurationException>(() => new EasyConfiguration().GetSection<SanityTests>("any"));
        }
    }
}
