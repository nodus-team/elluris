using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nodus.Elluris.Mvc.Extensions
{
    public static class ExtensionsMethods
    {
        public static string ToBrazilianDate(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy");
        }

        public static string ToBrazianDateTime(this DateTime valor)
        {
            return valor.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
