using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCredit.Api.Helpers
{
    public class DelegateHelper
    {
        public static Func<string, DateTimeOffset> DateHandler = (string x) =>
            !string.IsNullOrEmpty(x) ? DateTimeOffset.Parse(x) : default;
    }
}
