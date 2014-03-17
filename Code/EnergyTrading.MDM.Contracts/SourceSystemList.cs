namespace EnergyTrading.Mdm.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [CollectionDataContract(Namespace = "http://schemas.energytrading.com/mdm", ItemName = "SourceSystem")]
    [XmlRoot(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class SourceSystemList : List<SourceSystem>
    {
    }
}