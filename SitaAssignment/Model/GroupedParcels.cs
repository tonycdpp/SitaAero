using System.Collections.Generic;

namespace SitaAssignment.Model
{
    public class GroupedParcels
    {
        public string Handler { get; set; }
        public IEnumerable<Parcel> Parcels { get; set; }
    }
}