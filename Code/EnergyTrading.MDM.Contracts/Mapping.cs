namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm", Name = "Mapping")]
    [XmlRoot(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class Mapping : MdmId
    {
    }
}