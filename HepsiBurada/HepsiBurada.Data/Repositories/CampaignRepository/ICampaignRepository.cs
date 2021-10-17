using HepsiBurada.Data.Models;
using System.Threading.Tasks;

namespace HepsiBurada.Data.Repositories.CampaignRepository
{
    public interface ICampaignRepository : IBaseRepository<Campaign>
    {
        Task<Campaign> GetCampaignInfo(string name);
        Task<Campaign> GetCampaign(string productCode, int currentDuration);
    }
}