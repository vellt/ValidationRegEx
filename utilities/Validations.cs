using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationsRegEx.utilities
{
    public enum For
    {
        Int,
        Double,
        Number,
        Phone,
        Email
    }

    public static class Validations
    {
        private static class Pattern
        {
            public static string Int => @"^[0-9]+$";
            public static string Double => @"^-?(?:0|[1-9][0-9]*)\.?[0-9]+$";
            public static string Number => @"^[0-9]+([\\.][0-9]+)?$";
            public static string Phone => @"((?:\+?3|0)6)(?:-|\()?(\d{1,2})(?:-|\))?(\d{3})-?(\d{3,4})";
            public static string Email => @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        }

        public static bool IsValid(this string text, For validation)
        {
            return validation switch
            {
                For.Int => new Regex(Pattern.Int).IsMatch(text),
                For.Double => new Regex(Pattern.Double).IsMatch(text),
                For.Number => new Regex(Pattern.Number).IsMatch(text),
                For.Phone => new Regex(Pattern.Phone).IsMatch(text),
                For.Email => new Regex(Pattern.Email).IsMatch(text),
                _ => false,
            };
        }
    }
}
