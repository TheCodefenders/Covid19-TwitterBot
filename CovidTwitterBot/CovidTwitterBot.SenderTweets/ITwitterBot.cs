using CovidTwitterBot.Models;

namespace CovidTwitterBot.SenderTweets
{
    public interface ITwitterBot
    {
        long SendTweet(string status);
        void ReplyTweet(StateDataResult result, long idTweet);
    }
}
