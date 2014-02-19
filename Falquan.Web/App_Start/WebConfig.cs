using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Falquan.Web
{
    public static class WebConfig
    {
        public static class AppSettings
        {
            public static class Contact
            {
                private static string ContactEmailKey = "Contact.EmailAddress";
                private static string SmtpHostnameKey = "Contact.Smtp.Hostname";
                private static string SmtpPortKey = "Contact.Smtp.Port";
                private static string SmtpUsernameKey = "Contact.Smtp.Username";
                private static string SmtpPasswordKey = "Contact.Smtp.Password";

                public static string ContactEmail { get { return WebConfigurationManager.AppSettings[ContactEmailKey]; } }
                public static string SmtpHostname { get { return WebConfigurationManager.AppSettings[SmtpHostnameKey]; } }
                public static int SmtpPort { get { return int.Parse(WebConfigurationManager.AppSettings[SmtpPortKey]); } }
                public static string SmtpUsername { get { return WebConfigurationManager.AppSettings[SmtpUsernameKey]; } }
                public static string SmtpPassword { get { return WebConfigurationManager.AppSettings[SmtpPasswordKey]; } }
            }

            public static class Twitter
            {
                private static string ConsumerKeyKey = "Twitter.ConsumerKey";
                private static string ConsumerSecretKey = "Twitter.ConsumerSecret";
                private static string AccessTokenKey = "Twitter.AccessToken";
                private static string AccessSecretKey = "Twitter.AccessTokenSecret";
                private static string ScreenNameKey = "Twitter.ScreenName";

                public static string ConsumerKey { get { return WebConfigurationManager.AppSettings[ConsumerKeyKey]; } }
                public static string ConsumerSecret { get { return WebConfigurationManager.AppSettings[ConsumerSecretKey]; } }
                public static string AccessToken { get { return WebConfigurationManager.AppSettings[AccessTokenKey]; } }
                public static string AccessTokenSecret { get { return WebConfigurationManager.AppSettings[AccessSecretKey]; } }
                public static string ScreenName { get { return WebConfigurationManager.AppSettings[ScreenNameKey]; } }
            }
        }
    }
}