﻿namespace Mic.Web.Utility
{
    public class Statics
    {
        public static string BonApiBaseURL { get; set; }
        public static string AuthApiBaseURL { get; set; }
        public enum ApiMethod
        {
            GET, POST, PUT, DELETE
        }
    }
}
