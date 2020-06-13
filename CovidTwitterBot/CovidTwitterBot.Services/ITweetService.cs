using CovidTwitterBot.Models;

namespace CovidTwitterBot.Services
{
    public interface ITweetService
    {
        void MakeTweet(AllStatesResult statesResult);
    }
}
