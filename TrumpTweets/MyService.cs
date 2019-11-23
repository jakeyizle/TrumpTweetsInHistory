using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TweetSharp;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TrumpTweets.Model;
using System.IO;

namespace TrumpTweets
{
    public class MyService
    {
        const string key = "";
        const string secret = "";
        TwitterConfig twitterConfig;
        public MyService()
        {
        }
        public TweetDisplay GetTweet()
        {
            using (StreamReader r = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "config/config.json")))
            {
                string json = r.ReadToEnd();
                twitterConfig = JsonConvert.DeserializeObject<TwitterConfig>(json);
            }

            TwitterService service = new TwitterService(twitterConfig.key, twitterConfig.secret);
            ListTweetsOnUserTimelineOptions opt = new ListTweetsOnUserTimelineOptions
            {
                ScreenName = "realDonaldTrump",
                Count = 200,
                IncludeRts = false
            };
            var twitterTimeline = service.ListTweetsOnUserTimeline(opt).ToList();
            Random rnd = new Random();
            var tweet = twitterTimeline[rnd.Next(0, twitterTimeline.Count - 1)];

            var client = new RestClient($"https://history.muffinlabs.com/date/{tweet.CreatedDate.Month}/{tweet.CreatedDate.Day}");
            var response = client.Execute(new RestRequest(Method.GET));
            var eventsContent = JObject.Parse(response.Content).SelectTokens("$..Events..text");
            var years = JObject.Parse(response.Content).SelectTokens("$..Events..year");

            var index = rnd.Next(0, eventsContent.Count() - 1);
            var eventContent = eventsContent.ToList()[index];
            var year = years.ToList()[index];

            return new TweetDisplay(tweet, eventContent.ToString(), year.ToString());          
        }
    }
    
    class TwitterConfig
    {
        public string key;
        public string secret;
    }
}
