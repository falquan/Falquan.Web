using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Falquan.Web
{
    public static class DateTimeExtensions
    {
        public static string ToTwitterTimeStamp(this DateTime dateTime)
        {
            var timeSpan = DateTime.UtcNow - dateTime;

            if (timeSpan.TotalHours < 1)
            {
                return string.Format("{0}m", Math.Round(timeSpan.TotalMinutes));
            }
            else if (timeSpan.TotalDays < 1)
            {
                return string.Format("{0}h", Math.Round(timeSpan.TotalHours));
            }
            else //this needs to be in DD 3 letter month abbrev 30 Oct
            {
                return string.Format("{0:d MMM}", dateTime);
            }
        }

        public static string ToLongTwitterTimeStamp(this DateTime dateTime)
        {
            return string.Format("{0:h:mm tt - d MMM yy}", dateTime.ToLocalTime());
        }
    }
}