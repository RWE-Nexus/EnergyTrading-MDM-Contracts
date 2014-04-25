namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlRoot(Namespace = "http://schemas.rwe.com/nexus")]
    public class Fault : MdmFailure
    {
    }
}