using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YodaSlackBot.Extensions
{
    public static class DateTimeExtensions
    {
        public static long UnixTime(this DateTime dateTime)
        {
            var timespan = dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime();
            return (long) timespan.TotalSeconds;
        }
    }
}
