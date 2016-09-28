using System.Collections.Generic;
using System.Configuration;

namespace EasyConfigurationSection
{
    public class EasyConfiguration
    {
        private readonly IReadOnlyDictionary<string, string> sections;

        public EasyConfiguration(string name = "EasyConfiguration")
        {
            sections = ((EasyConfigurationSection)ConfigurationManager.GetSection(name)).Sections;
        }

        public bool ContainsSection(string name) => sections.ContainsKey(name);

        public bool TryGetSection<T>(string name, out T t) => TryGetSection(new XmlParser(), name, out t);

        public bool TryGetSection<T>(SectionParser parser, string name, out T t)
        {
            if (ContainsSection(name))
            {
                t = GetSection<T>(parser, name);
                return true;
            }
            {
                t = default(T);
                return false;
            }
        }

        public T GetSection<T>(string name) => GetSection<T>(new XmlParser(), name);

        public T GetSection<T>(SectionParser parser, string name) => parser.Parse<T>(sections[name]);
    }
}