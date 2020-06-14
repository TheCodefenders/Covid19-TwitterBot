using CovidTwitterBot.Models;
using Microsoft.Extensions.Logging;
using System;
using Tweetinvi;

namespace CovidTwitterBot.SenderTweets
{
    public class TwitterBot : ITwitterBot
    {
        private readonly ILogger<TwitterBot> _logger;
        
        public TwitterBot(ILogger<TwitterBot> log)
        {
            string customerKey = Environment.GetEnvironmentVariable("CustomKey");
            string customerKeySecret = Environment.GetEnvironmentVariable("CustomKeySecret");
            string accessToken = Environment.GetEnvironmentVariable("AccessToken");
            string accessTokenSecret = Environment.GetEnvironmentVariable("AccessTokenSecret");

            Auth.SetUserCredentials(customerKey, customerKeySecret, accessToken, accessTokenSecret);
            _logger = log;
        }

        public long SendTweet(string initialTweet)
        {
            User.GetAuthenticatedUser();

            var title = Tweet.PublishTweet(initialTweet);

            _logger.LogInformation($"Send start tweet {title.Id}");

            return title.Id;
        }

        public void ReplyTweet(StateDataResult result, long idTweet)
        {
            var text = $"Estado: {result.State}{Environment.NewLine}" +
                        $"Número de casos confirmados: {result.Confirmed}{Environment.NewLine}" +
                        $"Número de mortes: {result.Deaths}{Environment.NewLine}" +
                        $"Dados atualizados em: {result.Date.ToString("dd/MM/yyyy")}";

            var tweetReply = Tweet.PublishTweetInReplyTo(text, idTweet);

            _logger.LogInformation($"Send Reply {tweetReply.Id} to initial tweet {idTweet}");
        }

        public void FavoriteTweet(long idTweet)
        {
            if (Tweet.FavoriteTweet(idTweet))
                _logger.LogInformation($"Tweet {idTweet} setted as favorite");
        }
    }
}
