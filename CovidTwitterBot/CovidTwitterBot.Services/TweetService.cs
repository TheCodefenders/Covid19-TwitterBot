using CovidTwitterBot.Models;
using CovidTwitterBot.SenderTweets;
using System;

namespace CovidTwitterBot.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITwitterBot _twitterBot;

        public TweetService(ITwitterBot twitterBot)
        {
            _twitterBot = twitterBot;
        }

        public void MakeTweet(AllStatesResult statesResult)
        {
            var initialMensage = $"[Covid-19 - Atualização]{Environment.NewLine}" +
                                    $"Atualizações sobre o covid-19 nos estados brasileiros em {DateTime.Now.ToString("dd/MM/yyyy")}" +
                                    $"{Environment.NewLine}Siga a thread:";
            
            var idMainTweet = _twitterBot.SendTweet(initialMensage);

            foreach(var state in statesResult.Results)
            {
                _twitterBot.ReplyTweet(state, idMainTweet);
            }
        }
    }
}
