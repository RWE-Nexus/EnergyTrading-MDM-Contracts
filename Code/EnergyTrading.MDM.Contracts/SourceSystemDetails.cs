namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
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
