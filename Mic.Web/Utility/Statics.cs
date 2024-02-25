namespace Mic.Web.Utility
{
    public class Statics
    {
        public static string BonApiBaseURL { get; set; }
        public static string AuthApiBaseURL { get; set; }
        public const string Role_Admin = "ADMIN";
        public const string Role_Customer = "CUSTOMER";
        public enum ApiMethod
        {
            GET, POST, PUT, DELETE
        }
    }
}
