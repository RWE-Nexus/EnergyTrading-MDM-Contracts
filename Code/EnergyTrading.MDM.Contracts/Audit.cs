namespace EnergyTrading.Mdm.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class Audit
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public virtual MdmIdList LastChangeUser { get; set; }

        [DataMember(Order = 2)]
        [XmlElement]
        public virtual DateTime LastChangeTimestamp { get; set; }

        [DataMember(Order = 3)]
        [XmlElement]
        public virtual int VersionNumber { get; set; }
    }
}
