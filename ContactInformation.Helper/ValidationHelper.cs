using System.Text.RegularExpressions;

namespace ContactInformation.Helper
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string emailId)
        {
            var isValid = false;

            if (!string.IsNullOrEmpty(emailId))
            {
                isValid = Regex.IsMatch(emailId,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase);
            }

            return isValid;
        }
    }
}
