namespace EnergyTrading.Mdm.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [CollectionDataContract(Namespace = "http://schemas.rwe.com/nexus", ItemName = "ReferenceID")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus", TypeName = "NexusIdList")]
    public class MdmIdList : List<MdmId>
    {
    }
}
