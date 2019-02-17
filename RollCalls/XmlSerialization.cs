using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RollCalls
{
    public static class XmlSerialization
    {
        public static string Serialize<T>(T value
            , bool indent = false, bool omitXmlDeclaration = false
            , string prefix = "", string nameSpace = "")
        {

            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            settings.Indent = indent;
            settings.OmitXmlDeclaration = omitXmlDeclaration;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(prefix, nameSpace);

            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value, ns);
                }
                return textWriter.ToString();
            }
        }

        public static T DeSerialize<T>(string XML)
        {
            T o = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(XML))
            {
                o = (T)serializer.Deserialize(reader);
            }

            return o;
        }
    }
}
