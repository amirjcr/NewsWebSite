using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Common
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertShamsiToMiladi(this string date)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(date);
            return persianDateTime.ToDateTime();
        }

        public static string ConvertMiladiToShamsi(this DateTime? date, string format)
        {
            PersianDateTime persianDateTime = new PersianDateTime(date);
            return persianDateTime.ToString(format);
        }


        public static bool IsLeapYear(this DateTime? date)
        {
            PersianDateTime persianDateTime = new PersianDateTime(date);
            return persianDateTime.IsLeapYear;
        }

        public static DateTimeResult CheckShamsiDateTime(this string date)
        {
            try
            {
                DateTime miladiDate = PersianDateTime.Parse(date).ToDateTime();
                return new DateTimeResult { MiladiDate = miladiDate, IsShamsi = true };
            }

            catch
            {
                return new DateTimeResult { IsShamsi = false };
            }
        }

        public static DateTime DateTimeWithOutMilliSecends(DateTime dateTime) => dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));


        public static List<DateTime?> GetDateTimeForSearch(this string searchText)
        {
            DateTime? startDateTime = Convert.ToDateTime("01/01/01");
            DateTime? endDateTime = Convert.ToDateTime("01/01/01");
            var dateTimeResult = searchText.CheckShamsiDateTime();

            if (dateTimeResult.IsShamsi)
            {
                startDateTime = dateTimeResult.MiladiDate;
                if (searchText.Contains(":"))
                    endDateTime = startDateTime;
                else
                    endDateTime = startDateTime.Value.Date + new TimeSpan(23, 59, 59);
            }

            return new List<DateTime?>() { startDateTime, endDateTime };
        }
    }

    public class DateTimeResult
    {
        public bool IsShamsi { get; set; }
        public DateTime? MiladiDate { get; set; }
        public string searchText { get; set; }
    }

}
