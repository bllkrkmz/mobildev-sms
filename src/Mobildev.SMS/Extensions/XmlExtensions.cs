using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mobildev.SMS.Extensions
{
    public static class XmlExtensions
    {
        public static string Serialize<T>(this T obj, Encoding encoding, bool removeNamespace)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            using (var xmlTextWriter = new XmlTextWriter(memoryStream, encoding) { Formatting = Formatting.Indented })
            {
                if (removeNamespace)
                {
                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    xmlSerializer.Serialize(xmlTextWriter, obj, namespaces);
                }
                else
                    xmlSerializer.Serialize(xmlTextWriter, obj);

                var data = memoryStream.ToArray();
                var preamble = encoding.GetPreamble();

                if (preamble.Any())
                    return encoding.GetString(data, preamble.Length, data.Length - preamble.Length);

                return encoding.GetString(data);
            }
        }

        public static T Deserialize<T>(string xml) where T : new()
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xml))
            {
                var result = (T)xmlSerializer.Deserialize(stringReader);
                return result;
            }
        }
    }
}