using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetSharp;

namespace TrumpTweets.Model
{
    public class TweetDisplay
    {
        public TwitterStatus twitterStatus;
        public string eventContent;
        
        private string year;
        public TweetDisplay(TwitterStatus _twitterStatus, string _eventContent, string _year)
        {
            twitterStatus = _twitterStatus;
            eventContent = _eventContent;
            year = _year;
        }
        public string DisplayDate()
        {
            return twitterStatus.CreatedDate.ToString("dddd MMMM d, ") + year;
        }
    }
}
