using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Globalization;

namespace MovieManagement.Data.ValueConvertors
{
    public class DateTimeToChar8Converter:ValueConverter<DateTime,string>
    {
        public DateTimeToChar8Converter():base(
           dateTime=>dateTime.ToString("yyyyMMdd",CultureInfo.InvariantCulture),
           stringValue=>DateTime.ParseExact(stringValue,"yyyyMMdd", CultureInfo.InvariantCulture))
        {
            
        }
    }
}
