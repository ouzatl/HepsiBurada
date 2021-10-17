using ProtoBuf;

namespace HepsiBurada.Contract.Contracts.Order
{
    [ProtoContract]
    public class OrderContract
    {
        [ProtoMember(1)]
        public string ProductCode { get; set; }
        [ProtoMember(2)]
        public int Quantity { get; set; }
    }
}