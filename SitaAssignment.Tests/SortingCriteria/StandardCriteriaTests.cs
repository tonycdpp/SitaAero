using Microsoft.VisualStudio.TestTools.UnitTesting;
using SitaAssignment.Model;
using SitaAssignment.SortingCriteria;

namespace SitaAssignment.Tests.SortingCriteria
{
    [TestClass]
    public class StandardCriteriaTests : BaseUnitTest
    {
        public ICriteria Criteria = new StandardCriteria();
        public Parcel Parcel { get; set; }

        [TestMethod]
        public void Heavy_dept_should_handle_parcels_if_no_max_weight_set_when_below_insurance_value() //i.e. no maximum specified - unlimited
        {
            //Arrange
            Parcel = new Parcel
            {
                Value = 900m,
                Weight = 12
            };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, HeavyDepartmentMailHandler);

            //Assert
            Assert.IsTrue(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Heavy_dept_should_not_handle_parcels_if_no_max_weight_set_when_above_insurance_value_unless_signed_off() //i.e. no maximum specified, but value higher than 1k
        {
            //Arrange
            Parcel = new Parcel
            {
                Value = 1900m,
                Weight = 12,
                SignedOff = false
            };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, HeavyDepartmentMailHandler);

            //Assert
            Assert.IsFalse(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Heavy_dept_should_handle_parcels_above_insurance_value_when_signed_off() //i.e. no maximum specified, but value higher than 1k
        {
            //Arrange
            Parcel = new Parcel
            {
                Value = 1900m,
                Weight = 12,
                SignedOff = true
            };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, HeavyDepartmentMailHandler);

            //Assert
            Assert.IsTrue(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Heavy_dept_should_not_handle_parcels_if_max_weight_set_below_10kg() //i.e. no maximum specified, but value higher than 1k
        {
            //Arrange
            Parcel = new Parcel
            {
                Value = 900m,
                Weight = 9
            };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, HeavyDepartmentMailHandler);

            //Assert
            Assert.IsFalse(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Insurance_dept_should_always_handle_parcels_above_1k_no_matter_the_weight_if_parcel_not_already_signed_off() 
        {
            //Arrange
            Parcel = new Parcel { Value = 4242m,  Weight = 9, SignedOff = false};

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, InsuranceDepartmentMailHandler);

            //Assert
            Assert.IsTrue(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Insurance_dept_should_not_handle_parcels_above_1k_if_parcel_already_signed_off()
        {
            //Arrange
            Parcel = new Parcel { Value = 4242m, Weight = 9, SignedOff = true };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, InsuranceDepartmentMailHandler);

            //Assert
            Assert.IsFalse(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Regular_dept_should_handle_parcels_weighing_between_1kg_and_10kg()
        {
            //Arrange
            Parcel = new Parcel { Value = 242m, Weight = 3 };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, RegularDepartmentMailHandler);

            //Assert
            Assert.IsTrue(handlerMatchedWithParcel);
        }

        [TestMethod]
        public void Mail_dept_should_handle_parcels_weighing_up_to_1kg()
        {
            //Arrange
            Parcel = new Parcel { Value = 242m, Weight = 1 };

            //Act
            var handlerMatchedWithParcel = Criteria.Check(Parcel, MailDepartmentMailHandler);

            //Assert
            Assert.IsTrue(handlerMatchedWithParcel);
        }

    }
}
