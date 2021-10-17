using ProtoBuf;

namespace HepsiBurada.Contract.Contracts.Campaign
{
    [ProtoContract]
    public class CampaignContract
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string ProductCode { get; set; }
        [ProtoMember(3)]
        public int Duration { get; set; }
        [ProtoMember(4)]
        public int PriceManipulationLimit { get; set; }
        [ProtoMember(5)]
        public int TargetSalesCount { get; set; }
    }
}