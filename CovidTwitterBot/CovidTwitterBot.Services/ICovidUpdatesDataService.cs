using CovidTwitterBot.Models;
using System.Threading.Tasks;

namespace CovidTwitterBot.Services
{
    public interface ICovidUpdatesDataService
    {
        Task<AllStatesResult> GetAllStatesResult();
    }
}