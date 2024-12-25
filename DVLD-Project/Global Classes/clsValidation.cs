using System;
using System.Collections.Generic;
using System.Security.Cryptography; // to check its utility
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    public static class clsValidation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            // @"...": The @ symbol before the string denotes a verbatim string literal, which allows the use of backslashes without needing to escape them.
            //^: Asserts the position at the start of the string.
            // [a-zA-Z0-9.!#$%&'*+-/=?^_{|}~]+: Matches one or more characters from the set of allowed characters in the local part of an email before the @` symbol).
            // @: Matches the literal @ character.
            // [a-zA-Z0-9-]+: Matches one or more alphanumeric characters or hyphens in the domain part(before the first dot).
            // (?:\.[a-zA-Z0-9-]+)*: Non-capturing group that matches zero or more occurrences of a dot followed by one or more alphanumeric characters or hyphens.
            // $: Asserts the position at the end of the string.
            // other example:
            // Pattern: @"\b[at]\w+"
            // \b: Asserts a word boundary.Look for a word boundary. This ensures that the match starts at the beginning of a word.
            // [at]: Matches either 'a' or 't'.
            // \w +: Matches one or more word characters following the initial 'a' or 't'.
            Regex regex = new Regex(pattern);
            // The regular expression(regex) pattern itself:

            return regex.IsMatch(emailAddress); 

        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";
            // ^: Asserts the position at the start of the string.
            // $: Asserts the position at the end of the string.
            // [0-9]*: Matches zero or more digits(0-9).The * quantifier means "zero or more" of the preceding element.
            Regex regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            // (?:\.[0-9]*)?: Non-capturing group that optionally matches a dot(\.) followed by zero or more digits(0-9).
            // (?: ... ): A non-capturing group.
            // \.: Matches a literal dot.
            // ?: Makes the entire non-capturing group optional.
            Regex regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number)  || ValidateFloat(Number));

        }
    }
}
