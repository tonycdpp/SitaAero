using System.Xml.Serialization;

namespace SitaAssignment.Model
{
    [XmlRoot(ElementName = "Parcel")]
    public class Parcel
    {
        [XmlElement(ElementName = "Receipient")]
        public Receipient Receipient { get; set; }
        [XmlElement(ElementName = "Company")]
        public Company Company { get; set; }
        [XmlElement(ElementName = "MaxValue")]
        public decimal Value { get; set; }
        [XmlElement(ElementName = "Weight")]
        public double Weight { get; set; }
        public bool SignedOff { get; set; }
    }
}