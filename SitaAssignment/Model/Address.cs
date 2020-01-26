using System.Xml.Serialization;

namespace SitaAssignment.Model
{
	[XmlRoot(ElementName = "Address")]
	public class Address
	{
		[XmlElement(ElementName = "City")]
		public string City { get; set; }
		[XmlElement(ElementName = "HouseNumber")]
		public string HouseNumber { get; set; }
		[XmlElement(ElementName = "PostalCode")]
		public string PostalCode { get; set; }
		[XmlElement(ElementName = "Street")]
		public string Street { get; set; }
	}
}
