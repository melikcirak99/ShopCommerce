using System;

namespace ShopCommerce.UI.Functions
{
    public static class StaticFunctions
    {
        public static string CreateDayGuid()
        {
            return DateTime.Now.Minute.ToString()
                + DateTime.Now.Second.ToString()
                + DateTime.Now.Month.ToString()
                + DateTime.Now.Day.ToString()
                + DateTime.Now.Year.ToString();
        }
    }
}
