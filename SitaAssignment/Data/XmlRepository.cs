using System.Xml;
using System.Xml.Serialization;
using SitaAssignment.Configuration;

namespace SitaAssignment.Data
{
    public class XmlRepository : IXmlRepository
    {
        private readonly IConnectionStrings _filename;
        public XmlRepository(IConnectionStrings filename)
        {
            _filename = filename;
        }
        private static XmlReader _reader;
        public virtual T Get<T>()
        {
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ValidationType = ValidationType.DTD
            };
            _reader = XmlReader.Create(_filename.XmlFile, settings);
            var deserializer = new XmlSerializer(typeof(T));
            var stronglyTypedData = (T)deserializer.Deserialize(_reader);
            return stronglyTypedData;
        }
    }
}