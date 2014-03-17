namespace EnergyTrading.Mdm.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm")]
    [KnownType(typeof(Mapping))]
    public class MdmId : IEquatable<MdmId>
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        [XmlElement]
        public virtual Header Header { get; set; }

        [DataMember(Order = 2, Name = "MappingID", EmitDefaultValue = false)]
        [XmlElement(ElementName = "MappingID")]
        public virtual long? MappingId { get; set; }

        [XmlIgnore]
        public virtual bool MappingIdSpecified
        {
            get { return this.MappingId.HasValue; }
        }

        [DataMember(Order = 3, Name = "SystemID", EmitDefaultValue = false)]
        [XmlElement(ElementName = "SystemID")]
        public virtual string SystemId { get; set; }

        [DataMember(Order = 4)]
        [XmlElement]
        public virtual string SystemName { get; set; }

        [DataMember(Order = 5)]
        [XmlElement]
        public virtual string Identifier { get; set; }

        [DataMember(Order = 6, Name = "OriginatingSourceIND")]
        [XmlElement(ElementName = "OriginatingSourceIND")]
        public virtual bool SourceSystemOriginated { get; set; }

        [DataMember(Order = 7, Name = "IsMdmId")]
        [XmlElement(ElementName = "IsMdmId")]
        public virtual bool IsMdmId { get; set; }

        [DataMember(Order = 8, Name = "DefaultReverseIND", EmitDefaultValue = false)]
        [XmlElement(ElementName = "DefaultReverseIND")]
        public virtual bool? DefaultReverseInd { get; set; }

        [XmlIgnore]
        public virtual bool DefaultReverseIndSpecified
        {
            get { return this.DefaultReverseInd.HasValue && this.DefaultReverseInd.Value; }
        }

        [DataMember(Order = 9, EmitDefaultValue = false)]
        [XmlElement]
        public virtual DateTime? StartDate { get; set; }

        [XmlIgnore]
        public virtual bool StartDateSpecified
        {
            get { return this.StartDate.HasValue; }
        }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        [XmlElement]
        public virtual DateTime? EndDate { get; set; }

        [XmlIgnore]
        public virtual bool EndDateSpecified
        {
            get { return this.EndDate.HasValue; }
        }

        /// <copydocfrom cref="object.Equals(object)" />
        public override bool Equals(object obj)
        {
            return obj != null && this.Equals(obj as MdmId);
        }

        /// <copydocfrom cref="object.Equals(object)" />
        public virtual bool Equals(MdmId other)
        {
            if (other == null)
            {
                return false;
            }

            // NB Do we need MappingId and Validity?
            return this.SystemName == other.SystemName && this.Identifier == other.Identifier;
        }

        /// <copydocfrom cref="object.GetHashCode" />
        public override int GetHashCode()
        {
            return this.SystemName.GetHashCode() + (this.Identifier.GetHashCode() * 7);
        }

        /// <copydocfrom cref="object.ToString" />
        public override string ToString()
        {
            return this.SystemName + "/" + this.Identifier;
        }
    }
}