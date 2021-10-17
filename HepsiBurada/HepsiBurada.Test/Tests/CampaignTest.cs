using HepsiBurada.Contract.Contracts.Campaign;
using HepsiBurada.Test.Moqs;
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
                .CreateCampaign(new CampaignContract {Name ="C1", ProductCode="P1", Duration=10, PriceManipulationLimit=20, TargetSalesCount=100 });

            Assert.True(result);
        }

        [Fact]
        public async Task CREATE_CAMPAIGN_NULL_BODY_FAIL_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .CreateCampaign(null);

            Assert.False(result);
        }

        [Fact]
        public async Task CREATE_CAMPAIGN_NULL_NAME_FAIL_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .CreateCampaign(new CampaignContract { Name = null, ProductCode = "", Duration = 0, PriceManipulationLimit = 0, TargetSalesCount = 0 });

            Assert.False(result);
        }
        [Fact]
        public async Task CREATE_CAMPAIGN_NULL_PRODUCT_CODE_FAIL_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .CreateCampaign(new CampaignContract { Name = "C1", ProductCode = null, Duration = 0, PriceManipulationLimit = 0, TargetSalesCount = 0 });

            Assert.False(result);
        }


        [Fact]
        public async Task GET_CAMPAIGN_INFO_SUCCESS_CASE()
        {
            var result = await CampaignMoq.GetCampaignService()
                .GetCampaignInfo("C1");

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