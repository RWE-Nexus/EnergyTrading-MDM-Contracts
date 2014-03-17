namespace EnergyTrading.Mdm.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [CollectionDataContract(Namespace = "http://schemas.energytrading.com/mdm", ItemName = "ReferenceID")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class MdmIdList : List<MdmId>
    {
    }
}
