using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CosmicCakes.Helpers
{
    public static class MoneyExtensions
    {
        public static string ToMoneyString(this decimal amount, CultureInfo culture)
        {
            return string.Format(culture, "{0:0}", amount);
        }
    }
}