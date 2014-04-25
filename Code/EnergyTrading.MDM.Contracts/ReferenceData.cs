namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlRoot(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
    public class ReferenceData
    {
        [DataMember(Order = 3, Name = "Value", EmitDefaultValue = false)]
        [XmlElement(ElementName = "Value")]
        public virtual string Value { get; set; }

        [DataMember(Order = 4, Name = "ReferenceKey", EmitDefaultValue = false)]
        [XmlElement(ElementName = "ReferenceKey")]
        public virtual string ReferenceKey { get; set; }
    }
}