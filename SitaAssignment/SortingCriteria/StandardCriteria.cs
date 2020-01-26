using System;
using SitaAssignment.Configuration;
using SitaAssignment.Model;

namespace SitaAssignment.SortingCriteria
{
    public interface ICriteria
    {
        bool Check(Parcel parcel, MailHandler handler);
    }

    public class StandardCriteria : ICriteria
    {
        public bool Check(Parcel parcel, MailHandler handler)
        {
            return MinWeightCriteriaCheck(handler, parcel) &&
                   MaxWeightCriteriaCheck(parcel, handler) &&
                   MinValueCriteriaCheck(handler, parcel) &&
                   MaxValueCriteriaCheck(parcel, handler) && 
                   SignedOffCriteriaCheck(parcel, handler);
        }

        private bool SignedOffCriteriaCheck(Parcel parcel, MailHandler handler)
        {
            return handler.MaxValue != null || !parcel.SignedOff;
        }

        private bool MaxValueCriteriaCheck(Parcel parcel, MailHandler handler)
        {
            var maxValueCriteriaCheck = Convert.ToDecimal(parcel.Value) <= handler.MaxValue || handler.MaxValue == null || parcel.SignedOff;
            return maxValueCriteriaCheck;
        }

        private bool MinValueCriteriaCheck(MailHandler handler, Parcel parcel)
        {
            var minValueCriteriaCheck = handler.MinValue <= Convert.ToDecimal(parcel.Value) || handler.MinValue == null;
            return minValueCriteriaCheck;
        }

        private bool MaxWeightCriteriaCheck(Parcel parcel, MailHandler handler)
        {

            var maxWeightCriteriaCheck = Convert.ToDecimal(parcel.Weight) <= handler.MaxWeightInKg || handler.MaxWeightInKg == null;
            return maxWeightCriteriaCheck;
        }

        private bool MinWeightCriteriaCheck(MailHandler handler, Parcel parcel)
        {
            var minWeightCriteriaCheck = handler.MinWeightInKg <= Convert.ToDecimal(parcel.Weight) || handler.MinWeightInKg == null;
            return minWeightCriteriaCheck;
        }
    }
}