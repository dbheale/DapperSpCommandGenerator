using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSpGenerator
{
    internal static class StringExtensions
    {
        public static bool HasContent(this string? val)
        {
            return !string.IsNullOrEmpty(val?.Trim());
        }
    }
}
