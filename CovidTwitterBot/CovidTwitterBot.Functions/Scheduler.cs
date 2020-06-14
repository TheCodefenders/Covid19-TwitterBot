using CovidTwitterBot.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;

namespace CovidTwitterBot.Functions
{
    public class Scheduler
    {
        private readonly ICovidUpdatesDataService _covidUpdatesDataService;
        private readonly ITweetService _tweetService;

        public Scheduler(ICovidUpdatesDataService covidUpdatesDataService, ITweetService tweetService)
        {
            _covidUpdatesDataService = covidUpdatesDataService;
            _tweetService = tweetService;
        }

        [FunctionName("Scheduler")]
        public async void Run(
#if DEBUG
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
#else
            [TimerTrigger("0 0 8 * * *")]TimerInfo myTimer, 
#endif
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            var response = await _covidUpdatesDataService.GetAllStatesResult();
            
            log.LogInformation(response.Count.ToString());

            _tweetService.MakeTweet(response);
        }
    }
}
