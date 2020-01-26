using System.Collections.Generic;
using SitaAssignment.Model;

namespace SitaAssignment.Services
{
    public interface IParcelService
    {
        IEnumerable<Parcel> GetAllMail();
        IEnumerable<GroupedParcels> GetGroupedMail();
    }
}