using System.Xml.Serialization;

namespace SitaAssignment.Model
{
    [XmlRoot(ElementName = "Company")]
    public class Company
    {
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "CcNumber")]
        public string CcNumber { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }
}