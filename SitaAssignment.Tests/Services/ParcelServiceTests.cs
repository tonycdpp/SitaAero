using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitaAssignment.Model;
using SitaAssignment.Services;
using SitaAssignment.SortingCriteria;

namespace SitaAssignment.Tests.Services
{
    [TestClass]
    public class ParcelServiceTests : BaseUnitTest
    {
        [TestMethod]
        public void Parcel_service_calls_repository_and_returns_grouped_parcels()
        {
            //Arrange
            MockRepo.Setup(p => p.Get<Container>()).Returns(FakeParcels);
            var parcelService = new ParcelService(FakeHandlers, MockRepo.Object, new StandardCriteria());
            
            //Act
            var result = parcelService.GetGroupedMail();

            //Assert
            var regularDeptGroup = result.ToList().FirstOrDefault(x => x.Handler.Contains("Regular"));
            Assert.IsNotNull(regularDeptGroup);
            Assert.AreEqual(1, regularDeptGroup.Parcels.ToList().Count()); //we expect a parcel record allocated to Regular department
        }
    }
}
