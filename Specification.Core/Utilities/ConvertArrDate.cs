using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Core.Utilities
{
    public class ConvertArrDate
    {
        public static int[] GetDateIntArr(DateTime dt) =>
            [dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second];

        public static DateTime ArrIntToDate(int[] dt) =>
            new DateTime(dt[0], dt[1], dt[2], dt[3], dt[4], dt[5]);
    }
}
