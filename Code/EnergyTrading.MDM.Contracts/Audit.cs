namespace EnergyTrading.Mdm.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
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

        [DataMember(Order = 4)]
        [XmlElement]
        public virtual ulong Version { get; set; }

    }
}
