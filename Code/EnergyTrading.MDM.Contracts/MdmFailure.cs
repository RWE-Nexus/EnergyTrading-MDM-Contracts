namespace EnergyTrading.Mdm.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using EnergyTrading.Contracts.Atom;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm", Name = "MdmFailureType")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm", TypeName = "MdmFailureType")]
    public class MdmFailure
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public virtual string Message { get; set; }

        [DataMember(Order = 2)]
        [XmlElement]
        public virtual string Reason { get; set; }

        [DataMember(Order = 3)]
        [XmlElement]
        public virtual string SourceSystem { get; set; }

        [DataMember(Order = 4)]
        [XmlElement]
        public virtual string Mapping { get; set; }

        [DataMember(Order = 5)]
        [XmlElement]
        public virtual DateTime? AsOfDate { get; set; }

        [DataMember(Order = 6)]
        [XmlElement]
        public virtual string Identifier { get; set; }

        [DataMember(Order = 7, EmitDefaultValue = false)]
        [XmlElement]
        public virtual Link Link { get; set; }
    }
}