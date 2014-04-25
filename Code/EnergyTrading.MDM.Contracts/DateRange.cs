namespace EnergyTrading.Mdm.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.rwe.com/nexus")]
    [XmlType(Namespace = "http://schemas.rwe.com/nexus")]
    public class DateRange
    {
        [DataMember(Order = 1)]
        [XmlElement]
        public virtual DateTime? StartDate { get; set; }

        [XmlIgnore]
        public virtual bool StartDateSpecified
        {
            get { return this.StartDate.HasValue; }
        }

        [DataMember(Order = 2)]
        [XmlElement]
        public virtual DateTime? EndDate { get; set; }

        [XmlIgnore]
        public virtual bool EndDateSpecified
        {
            get { return this.EndDate.HasValue; }
        }
    }
}
