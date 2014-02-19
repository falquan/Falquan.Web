using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace Falquan.Web.Controllers
{
    public class TwitterController : Controller
    {
        private static TwitterService _twitter;

        //
        // GET: /Twitter/

        [OutputCache(Duration = 300)]
        public ActionResult Timeline()
        {
            if (_twitter == null)
                Authenticate();

            var timeline = Get(10);

            return PartialView("_TwitterTimeline", timeline);
        }

        [OutputCache(Duration = 300)]
        public ActionResult Index()
        {
            if (_twitter == null)
                Authenticate();

            var timeline = Get(10);

            return View(timeline);
        }

        private static void Authenticate()
        {
            var clientInfo = new TwitterClientInfo()
            {
                ConsumerKey = WebConfig.AppSettings.Twitter.ConsumerKey,
                ConsumerSecret = WebConfig.AppSettings.Twitter.ConsumerSecret
            };

            _twitter = new TwitterService(clientInfo);
            _twitter.AuthenticateWith(WebConfig.AppSettings.Twitter.AccessToken, WebConfig.AppSettings.Twitter.AccessTokenSecret);
        }

        private static IEnumerable<TwitterStatus> Get(int count)
        {
            return _twitter.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions()
                                                    {
                                                        ScreenName = WebConfig.AppSettings.Twitter.ScreenName,
                                                        Count = count, IncludeRts = true,
                                                        ExcludeReplies = false
                                                    });
        }

        //public static void SetCertificatePolicy()
        //{
        //    ServicePointManager.ServerCertificateValidationCallback += TwitterApi.RemoteCertificateValidate;
        //}

        ///// <summary>
        ///// Twitter remote cert does not validate against root certs. Ignore and look for errors in policy only.
        ///// </summary>
        //private static bool RemoteCertificateValidate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{
        //    return errors == SslPolicyErrors.None ? true : false;
        //}
    }
}
