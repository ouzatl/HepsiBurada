using HepsiBurada.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HepsiBurada.Data.Repositories.CampaignRepository
{
    public class CampaignRepository : BaseRepository<Campaign>, ICampaignRepository
    {
        private readonly DbContext _dbContext;

        public CampaignRepository(HepsiBuradaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Campaign> GetCampaignInfo(string name)
        {
            var campaign = await _dbContext.Set<Campaign>()
                .FirstOrDefaultAsync(x => x.Name == name);

            return campaign;
        }

        public async Task<Campaign> GetCampaign(string productCode, int currentDuration)
        {
            var campaign = await _dbContext.Set<Campaign>()
                .FirstOrDefaultAsync(x => x.ProductCode == productCode && x.Duration > currentDuration);

            return campaign;
        }
    }
}