using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace EasyConfigurationSection.Tests
{
    public class XmlParserTests
    {
        [Test]
        public void FooTest()
        {
            var foo = new EasyConfiguration().GetSection<Foo>("First");
            Assert.AreEqual("Bar", foo.Content);
        }

        [Test]
        public void BarTest()
        {
            var bar = new EasyConfiguration().GetSection<Bar>("Second");
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, bar.Foo);
        }

        public class Foo
        {
            [XmlText]
            public string Content { get; set; }
        }

        public class Bar
        {
            [XmlElement("Foo")]
            public List<int> Foo { get; set; }
        }
    }
}