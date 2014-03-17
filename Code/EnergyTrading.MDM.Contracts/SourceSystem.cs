﻿namespace EnergyTrading.Mdm.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using EnergyTrading.Contracts.Atom;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlRoot(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    public class SourceSystem : IMdmEntity
    {
        public SourceSystem()
        {
            this.Identifiers = new MdmIdList();
            this.Details = new SourceSystemDetails();
            this.Links = new List<Link>();
        }

        [DataMember(Order = 1)]
        [XmlArray]
        [XmlArrayItem("ReferenceID")]
        public virtual MdmIdList Identifiers { get; set; }

        [DataMember(Order = 2)]
        [XmlElement]
        public virtual SourceSystemDetails Details { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        [XmlElement]
        public virtual SystemData MdmSystemData { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        [XmlElement]
        public virtual Audit Audit { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        [XmlElement("link", Namespace = "http://www.w3.org/2005/Atom")]
        public virtual List<Link> Links { get; set; }

        object IMdmEntity.Details
        {
            get { return this.Details; }
            set { this.Details = (SourceSystemDetails)value; }
        }
    }
}
