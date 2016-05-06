using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Web.Utilities
{
    public static class XPath
    {
        public static string ToLowerCase(string parameter)
        {
            return "translate(" + parameter + ", 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz')";
        }
    }
}
