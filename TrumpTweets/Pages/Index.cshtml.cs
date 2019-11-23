using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TweetSharp;

namespace TrumpTweets.Pages
{
    public class IndexModel : PageModel
    {
        public TwitterStatus tweet;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Tweet Twitter = new Tweet();
            tweet = Twitter.GetTweet();
            Twitter.GetEvent(tweet);
        }
    }
}
