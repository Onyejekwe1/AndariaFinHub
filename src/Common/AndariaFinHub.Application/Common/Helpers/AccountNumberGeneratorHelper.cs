using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Common.Helpers
{
    public static class AccountNumberGeneratorHelper
    {
        public static string RandomNumString(int length)
        {
            return DateTime.UtcNow.Ticks.ToString().Substring(length);
        }
    }
}
