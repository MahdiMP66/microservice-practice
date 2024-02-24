using System.Text.RegularExpressions;

namespace AuthAPI.Utility
{
    public class Statics
    {
        public static bool IsValidEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex re = new Regex(pattern);
            return re.IsMatch(email);
        }
    }
}
