using System;

namespace CovidAssignment.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Return ISO Date Format
        /// </summary>
        /// <param name="time">Time</param>
        /// <returns>ISO Date Format String</returns>
        public static string StringExtension(this DateTime time)
        {
            return $"{FormatInt(time.Year)}-{FormatInt(time.Month)}-{FormatInt(time.Day)}T{FormatInt(time.Hour)}:{FormatInt(time.Minute)}:{FormatInt(time.Second)}Z";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static string FormatInt(int x)
        {
            if (x < 10)
            {
                return $"0{x}";
            }
            return x.ToString();
        }
    }
}