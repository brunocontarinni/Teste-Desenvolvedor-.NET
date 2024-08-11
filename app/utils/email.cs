using System;
using System.Text.RegularExpressions;

namespace EmailValidatorSpace
{
    class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}