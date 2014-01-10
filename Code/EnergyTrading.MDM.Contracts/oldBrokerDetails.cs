namespace RWEST.Nexus.MDM.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
    public class oldBrokerDetails
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public EntityId Party { get; set; }

        [DataMember(Order = 2)]
        [XmlElement]
        public string Name { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        [XmlElement]
        public string FaxNumber { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        [XmlElement]
        public string TelephoneNumber { get; set; }

        [DataMember(Order = 5)]
        [XmlElement]
        public decimal Rate { get; set; }
    }
}