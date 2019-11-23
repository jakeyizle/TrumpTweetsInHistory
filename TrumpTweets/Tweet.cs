using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TweetSharp;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrumpTweets
{
    public class Tweet
    {
        const string key = "FBBOEyHUJiK0TFZ9xYqHPHSsv";
        const string secret = "AJhT5N0hTxcbcfUQWdJZkxIbWznAbQMChAyrojUEjEqjfZURPJ";
        public TwitterStatus GetTweet()
        {
            TwitterService service = new TwitterService(key, secret);
            ListTweetsOnUserTimelineOptions opt = new ListTweetsOnUserTimelineOptions
            {
                ScreenName = "realDonaldTrump",
                Count = 200
            };
            var results = service.ListTweetsOnUserTimeline(opt).ToList();
            Random rnd = new Random();
            var result = results[rnd.Next(0, results.Count - 1)];           
            return result;          
        }

        public void GetEvent(TwitterStatus tweet)
        {
            int day = tweet.CreatedDate.Day;
            int month = tweet.CreatedDate.Month;
            var client = new RestClient($"https://history.muffinlabs.com/date/{month}/{day}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var test = JObject.Parse(content).SelectTokens("$..Events..text");
            Random rnd = new Random();
            var result = test.ToList()[rnd.Next(0, test.Count() - 1)];
        }
    }
}
