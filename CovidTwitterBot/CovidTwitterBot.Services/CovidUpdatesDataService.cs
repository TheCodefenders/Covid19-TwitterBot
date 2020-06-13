using CovidTwitterBot.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidTwitterBot.Services
{
    public class CovidUpdatesDataService : ICovidUpdatesDataService
    {
        private readonly HttpClient _httpClient;

        public CovidUpdatesDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AllStatesResult> GetAllStatesResult()
        {
            var response = await _httpClient.GetAsync("https://brasil.io/api/dataset/covid19/caso/data?is_last=True&place_type=state");
            var statesUpdateData = JsonConvert.DeserializeObject<AllStatesResult>(await response.Content.ReadAsStringAsync());

            return statesUpdateData;
        }
    }
}
