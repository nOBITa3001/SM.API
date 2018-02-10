using System;

namespace SM.API.Extensions
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age++;

            return age;
        }
    }
}