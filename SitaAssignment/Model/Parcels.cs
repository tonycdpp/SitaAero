using System.Collections.Generic;
using System.Xml.Serialization;

namespace SitaAssignment.Model
{
    [XmlRoot(ElementName = "parcels")]
    public class Parcels
    {
        [XmlElement(ElementName = "Parcel")]
        public List<Parcel> Parcel { get; set; }
    }
}