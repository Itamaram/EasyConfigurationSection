using NUnit.Framework;

namespace EasyConfigurationSection.Tests
{
    public class EasyConfigurationSectionTests
    {
        [Test]
        public void EmptySectionTest()
        {
            Assert.DoesNotThrow(() => new EasyConfiguration("Empty"));
        }

        [Test]
        public void NoChildrenSectionTest()
        {
            Assert.DoesNotThrow(() => new EasyConfiguration("NoChildren"));
        }

        [Test]
        public void UndefinedSection()
        {
            Assert.DoesNotThrow(() => new EasyConfiguration("SectionThatDoesntExist"));
        }
    }
}