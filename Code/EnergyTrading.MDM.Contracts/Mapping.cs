namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus", Name = "Mapping")]
    [XmlRoot(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
    public class Mapping : MdmId
    {
    }
}