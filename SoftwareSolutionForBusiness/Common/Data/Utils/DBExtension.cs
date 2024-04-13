using System;

namespace SoftwareSolutionForBusiness.Common.Data.Utils
{
    internal static class DBExtension
    {
        public static object GetValidValue(object value)
        {
            return value == null ? DBNull.Value : value;
        }
    }
}
