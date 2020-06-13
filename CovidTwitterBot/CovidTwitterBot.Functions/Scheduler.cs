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

        public Scheduler(ICovidUpdatesDataService covidUpdatesDataService)
        {
            _covidUpdatesDataService = covidUpdatesDataService;
        }

        [FunctionName("Scheduler")]
        public async void Run(
            //[TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, 
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            var response = await _covidUpdatesDataService.GetAllStatesResult();
            
            log.LogInformation(response.Count.ToString());

            #region TODO: Call tweetService here
            #endregion
        }
    }
}
