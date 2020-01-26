using System.Xml.Serialization;

namespace SitaAssignment.Model
{
    [XmlRoot(ElementName = "Receipient")]
    public class Receipient
    {
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
    }
}