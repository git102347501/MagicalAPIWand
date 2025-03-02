using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalAPIWand
{
    public static class DictionaryHelper
    {
        public static string ConvertDictionaryToText(this Dictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary), "");
            }

            StringBuilder sb = new StringBuilder();
            foreach (var kvp in dictionary)
            {
                sb.AppendLine($"{kvp.Key}:{kvp.Value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
