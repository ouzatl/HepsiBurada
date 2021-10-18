using AutoMapper;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Campaign;
using HepsiBurada.Data.Models;
using HepsiBurada.Data.Repositories.CampaignRepository;
using HepsiBurada.Service.Services.CampaignService;
using HepsiBurada.Test.Moqs;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace HepsiBurada.Test.Tests
{
    public class CampaignTest
    {
        [Fact]
        public async Task CREATE_CAMPAIGN_SUCCES_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .CreateCampaign(new CampaignContract { Name = "C1", ProductCode = "P1", Duration = 10, PriceManipulationLimit = 20, TargetSalesCount = 100 });

            Assert.True(result);
        }

        [Fact]
        public async Task GET_CAMPAIGN_INFO_SUCCESS_CASE()
        {
            var campaignRepo = new Mock<ICampaignRepository>();
            var campaign = new Mock<ICampaignService>();
            var memCache = new Mock<IMemoryCache>();
            var mapper = new Mock<IMapper>();
            var logger = new Mock<ICompositeLogger>();

            campaignRepo.Setup(p => p.GetCampaignInfo("C1"))
                .ReturnsAsync(new Campaign { Name = "C1", Duration = 5, PriceManipulationLimit = 20, ProductCode = "P1", TargetSalesCount = 100 });

            var orderservice = new CampaignService(campaignRepo.Object, logger.Object, mapper.Object, memCache.Object);

            var result = await orderservice.GetCampaignInfo("C1");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GET_CAMPAIGN_INFO_NULL_NAME_PARAMETER_FAIL_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .GetCampaignInfo(null);

            Assert.Null(result);
        }

        [Fact]
        public async Task GET_CAMPAIGN_INFO_EMPTY_NAME_PARAMETER_FAIL_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .GetCampaignInfo("");

            Assert.Null(result);
        }
    }
}