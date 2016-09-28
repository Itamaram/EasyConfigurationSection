using System.IO;
using System.Xml.Serialization;

namespace EasyConfigurationSection
{
    public interface SectionParser
    {
        T Parse<T>(string s);
    }

    public class XmlParser : SectionParser
    {
        public T Parse<T>(string s)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(new StringReader(s));
        }
    }
}