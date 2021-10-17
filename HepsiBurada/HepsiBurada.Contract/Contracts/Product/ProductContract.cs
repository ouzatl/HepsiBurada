using ProtoBuf;

namespace HepsiBurada.Contract.Contracts.Product
{
    [ProtoContract]
    public class ProductContract
    {
        [ProtoMember(1)]
        public string ProductCode { get; set; }
        [ProtoMember(2)]
        public double Price { get; set; }
        [ProtoMember(3)]
        public int Stock { get; set; }
    }
}