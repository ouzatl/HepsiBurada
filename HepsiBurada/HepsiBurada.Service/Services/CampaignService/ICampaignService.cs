using HepsiBurada.Contract.Contracts.Campaign;
using System;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.CampaignService
{
    public interface ICampaignService
    {
        Task<bool> CreateCampaign(CampaignContract campaign);
        Task<CampaignStatusContract> GetCampaignInfo(string name);
        DateTime GetAndSetTime(int hour);
    }
}