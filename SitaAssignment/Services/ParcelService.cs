using System.Collections.Generic;
using System.Linq;
using SitaAssignment.Configuration;
using SitaAssignment.Data;
using SitaAssignment.Model;
using SitaAssignment.SortingCriteria;

namespace SitaAssignment.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IXmlRepository _repository;
        private readonly ICriteria _criteria;
        private readonly IMailHandlersConfiguration _configuration;

        public ParcelService(IMailHandlersConfiguration configuration, IXmlRepository repository, ICriteria criteria)
        {
            _repository = repository;
            _criteria = criteria;
            _configuration = configuration;
        }

        public IEnumerable<Parcel> GetAllMail()
        {
            return _repository.Get<Container>().Parcels.Parcel;
        }

        public IEnumerable<GroupedParcels> GetGroupedMail()
        {
            var groupedParcels = new List<GroupedParcels>();
            var allMail = _repository.Get<Container>();

            foreach (var handler in _configuration.MailHandlers)
            {
                var instance = new GroupedParcels
                {
                    Handler = handler.Name,
                    Parcels = allMail.Parcels.Parcel.Where(parcel => _criteria.Check(parcel, handler))
                };
                groupedParcels.Add(instance);
            }

            return groupedParcels;
        }
    }
}