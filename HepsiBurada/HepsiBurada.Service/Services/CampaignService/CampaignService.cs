using AutoMapper;
using HepsiBurada.Common.Constants;
using HepsiBurada.Common.Enums;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Campaign;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.CampaignRepository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace HepsiBurada.Service.Services.CampaignService
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly ICompositeLogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly string cacheKey = CacheKeyConstant.CURRENT_HOUR;


        public CampaignService(
            ICampaignRepository campaignRepository,
            ICompositeLogger logger,
            IMapper mapper,
            IMemoryCache memoryCache
            )
        {
            _campaignRepository = campaignRepository;
            _logger = logger;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<bool> CreateCampaign(CampaignContract campaign)
        {
            try
            {
                var campaignModel = _mapper.Map<Campaign>(campaign);
                await _campaignRepository.Add(campaignModel);
            }
            catch (System.Exception ex)
            {
                _logger.Error("CreateCampaign", ex);
                return false;
            }

            return true;
        }
        public async Task<CampaignStatusContract> GetCampaignInfo(string name)
        {
            try
            {
                var campaign = await _campaignRepository.GetCampaignInfo(name);
                var currentDuration = _memoryCache.Get(cacheKey) ?? 0;
                var campaignStatusContract = new CampaignStatusContract { Name = name, TargetSales = campaign.TargetSalesCount };
                if (campaign.Duration < (int)currentDuration)
                    campaignStatusContract.Status = CampaignStatusEnum.Ended;
                else
                    campaignStatusContract.Status = CampaignStatusEnum.Active;

                return campaignStatusContract;
            }
            catch (System.Exception ex)
            {
                _logger.Error("GetCampaignInfo", ex);
                return null;
            }
        }
        public DateTime GetAndSetTime(int hour)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out int time))
                _memoryCache.Set(cacheKey, default(int));

            time = 60 * hour + time;
            var totalDayHour = 24 * 60;
            if (time > totalDayHour)
                time = time - totalDayHour;
            _memoryCache.Set(cacheKey, time);

            TimeSpan ts = TimeSpan.FromHours(time / 60);
            DateTime dt = Convert.ToDateTime(ts.ToString());

            return dt;
        }
    }
}