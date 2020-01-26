using System.Collections.Generic;
using Moq;
using SitaAssignment.Configuration;
using SitaAssignment.Data;
using SitaAssignment.Model;
using SitaAssignment.SortingCriteria;

namespace SitaAssignment.Tests
{
    public class BaseUnitTest
    {
        #region Mocks

        public static Mock<IConnectionStrings> MockConnStr = new Mock<IConnectionStrings>();
        public static Mock<XmlRepository> MockRepo = new Mock<XmlRepository>(MockConnStr.Object);

        #endregion

        #region Fakes

        public MailHandlersConfiguration FakeHandlers = new MailHandlersConfiguration
        {
            MailHandlers = new List<MailHandler> { MailDepartmentMailHandler, RegularDepartmentMailHandler, HeavyDepartmentMailHandler, InsuranceDepartmentMailHandler }
        };

        public Container FakeParcels = new Container
        {
            Id = "1234",
            Parcels = new Parcels
            {
                Parcel = new List<Parcel>
                {
                    new Parcel
                    {
                        Company = new Company  { Name = "Sender" },
                        Receipient = new Receipient { Name = "Recipient" },
                        Value = 200m,
                        Weight = 2
                    }
                }
            }
        };

        public static MailHandler MailDepartmentMailHandler = new MailHandler
        {
            Name = "Mail Department - Test",
            MinWeightInKg = null,
            MaxWeightInKg = 1.0m,
            MinValue = null,
            MaxValue = 1000m
        };

        public static MailHandler RegularDepartmentMailHandler = new MailHandler
        {
            Name = "Regular Department - Test",
            MinWeightInKg = 1.001m,
            MaxWeightInKg = 10m,
            MinValue = null,
            MaxValue = 1000m
        };

        public static MailHandler HeavyDepartmentMailHandler = new MailHandler
        {
            Name = "Heavy Department - Test",
            MinWeightInKg = 10.001m,
            MaxWeightInKg = null,
            MinValue = null,
            MaxValue = 1000m
        };

        public static MailHandler InsuranceDepartmentMailHandler = new MailHandler
        {
            Name = "Insurance Department - Test",
            MinWeightInKg = null,
            MaxWeightInKg = null,
            MinValue = 1000.01m,
            MaxValue = null
        };

        #endregion
    }
}