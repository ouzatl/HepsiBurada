using System.Threading.Tasks;
using HepsiBurada.Common.Logging;
using HepsiBurada.Contract.Contracts.Campaign;
using HepsiBurada.Service.Services.CampaignService;
using Microsoft.AspNetCore.Mvc;

namespace HepsiBurada.API.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;
        private readonly ICompositeLogger _logger;

        public CampaignController(
            ICampaignService campaignService,
            ICompositeLogger logger
            )
        {
            _campaignService = campaignService;
            _logger = logger;
        }

        [HttpPost("create_campaign")]
        public async Task<IActionResult> CreateCampaign([FromBody] CampaignContract campaign)
        {
            if (campaign == null || string.IsNullOrEmpty(campaign.ProductCode) || string.IsNullOrEmpty(campaign.Name))
                return BadRequest();

            var result = await _campaignService.CreateCampaign(campaign);
            if (result)
                return Ok($"Campaign created; name {campaign.Name}, product {campaign.ProductCode}, duration {campaign.Duration}, limit {campaign.PriceManipulationLimit}, target sales count {campaign.TargetSalesCount}");
            else
                return NoContent();
        }

        [HttpGet("get_campaign_info")]
        public async Task<IActionResult> GetCampaignInfo(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var result = await _campaignService.GetCampaignInfo(name);
            var abc = result.Status.ToString();
            if (result != null)
                return Ok($"Campaign {name} info; Status {result.Status.ToString()}, Target Sales {result.TargetSales}, Total Sales  {result.TotalSales}, Turnover  {result.TurnOver}, Average Item Price  {result.AverageItemPrice}");
            else
                return NotFound();
        }

        [HttpPost("increase_time")]
        public IActionResult IncreaseTime(int hour)
        {
            var result = _campaignService.GetAndSetTime(hour);
            return Ok(string.Format("Time is {0}", result.ToString("hh':'mm")));
        }
    }
}