namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class SourceSystemDetails
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public virtual string Name { get; set; }

        [DataMember(Order = 3)]
        [XmlElement]
        public virtual EntityId Parent { get; set; }
    }
}
