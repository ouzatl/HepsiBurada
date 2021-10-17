using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Service.Services.CampaignService;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace HepsiBurada.Test.Moqs
{
    public class CampaignMoq
    {
        #region Moqs

        public static ICompositeLogger LoggerMoq() => Mock.Of<ICompositeLogger>();
        public static ICampaignRepository CampaignRepositoryMoq() => Mock.Of<ICampaignRepository>();
        public static IMapper MapperMoq() => Mock.Of<IMapper>();
        public static IMemoryCache MemoryCacheMoq()=> Mock.Of<IMemoryCache>();

        #endregion

        #region GetMoqs

        public static ICampaignService GetCampaignService() => new CampaignService(CampaignRepositoryMoq(), LoggerMoq(), MapperMoq(), MemoryCacheMoq());

        #endregion
    }
}