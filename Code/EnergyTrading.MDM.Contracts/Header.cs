namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class Header
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public virtual string Version { get; set; }

        [DataMember(Order = 2)]
        [XmlElement]
        public virtual string Notes { get; set; }
    }
}