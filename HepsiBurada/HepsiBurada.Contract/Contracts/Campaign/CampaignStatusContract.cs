using HepsiBurada.Common.Enums;
using ProtoBuf;

namespace HepsiBurada.Contract.Contracts.Campaign
{
    [ProtoContract]
    public class CampaignStatusContract
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public CampaignStatusEnum Status { get; set; }
        [ProtoMember(3)]
        public int TargetSales { get; set; }
        [ProtoMember(4)]
        public int TotalSales { get; set; }
        [ProtoMember(5)]
        public int TurnOver { get; set; }
        [ProtoMember(6)]
        public double AverageItemPrice { get; set; }
    }
}