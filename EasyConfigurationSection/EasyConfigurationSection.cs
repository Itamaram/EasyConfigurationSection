using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace EasyConfigurationSection
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class EasyConfigurationSection : ConfigurationSection
    {
        private readonly Dictionary<string, string> sections = new Dictionary<string, string>();
        public IReadOnlyDictionary<string, string> Sections => sections;

        protected override void DeserializeSection(XmlReader reader)
        {
            sections.Clear();

            //Read into first position
            reader.Read();

            //Read past first position
            reader.Read();

            while (reader.NodeType != XmlNodeType.None)
            {
                if (reader.NodeType == XmlNodeType.Element)
                    sections[reader.Name] = reader.ReadInnerXml();
                else
                    reader.Read();
            }
        }
    }
}
