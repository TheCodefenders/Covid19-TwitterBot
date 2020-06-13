using CovidTwitterBot.Functions;
using CovidTwitterBot.SenderTweets;
using CovidTwitterBot.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace CovidTwitterBot.Functions
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ICovidUpdatesDataService, CovidUpdatesDataService>();
            builder.Services.AddScoped<ITweetService, TweetService>();
            builder.Services.AddScoped<ITwitterBot, TwitterBot>();

            builder.Services.AddLogging();
        }
    }
}
