using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TrumpTweets.Model;
using TweetSharp;

namespace TrumpTweets.Pages
{
    public class IndexModel : PageModel
    {
        public TweetDisplay tweetDisplay;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<PageResult> OnGetAsync()
        {            
            MyService Twitter = new MyService();
            tweetDisplay = await Twitter.GetTweetAsync();
            return Page();
        }
    }
}
