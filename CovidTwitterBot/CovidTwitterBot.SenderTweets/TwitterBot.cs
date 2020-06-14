using CovidTwitterBot.Models;
using System;
using Tweetinvi;

namespace CovidTwitterBot.SenderTweets
{
    public class TwitterBot : ITwitterBot
    {
        public TwitterBot()
        {
            string customerKey = Environment.GetEnvironmentVariable("CustomKey");
            string customerKeySecret = Environment.GetEnvironmentVariable("CustomKeySecret");
            string accessToken = Environment.GetEnvironmentVariable("AccessToken");
            string accessTokenSecret = Environment.GetEnvironmentVariable("AccessTokenSecret");

            Auth.SetUserCredentials(customerKey, customerKeySecret, accessToken, accessTokenSecret);
        }

        public long SendTweet(string initialTweet)
        {
            User.GetAuthenticatedUser();

            var title = Tweet.PublishTweet(initialTweet);

            Console.WriteLine($"Send start tweet {title.Id}");

            return title.Id;
        }

        public void ReplyTweet(StateDataResult result, long idTweet)
        {
            var text = $"Estado: {result.State}{Environment.NewLine}" +
                        $"Número de casos confirmados: {result.Confirmed}{Environment.NewLine}" +
                        $"Número de mortes: {result.Deaths}{Environment.NewLine}" +
                        $"Dados atualizados em: {result.Date.ToString("dd/MM/yyyy")}";

            var tweetReply = Tweet.PublishTweetInReplyTo(text, idTweet);

            Console.WriteLine($"Send Reply {tweetReply.Id} to initial tweet {idTweet}");
        }

        public void FavoriteTweet(long idTweet)
        {
            if (Tweet.FavoriteTweet(idTweet))
                _logger.LogInformation($"Tweet {idTweet} setted as favorite");
        }
    }
}
