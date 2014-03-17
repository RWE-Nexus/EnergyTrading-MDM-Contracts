namespace EnergyTrading.Mdm.Contracts
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [DataContract(Namespace = "http://schemas.energytrading.com/mdm", Name = "MappingResponseType")]
    [XmlRoot(Namespace = "http://schemas.energytrading.com/mdm")]
    [XmlType(Namespace = "http://schemas.energytrading.com/mdm", TypeName = "MappingResponseType")]
    public class MappingResponse
    {
        public MappingResponse()
        {
            this.Mappings = new MdmIdList();
        }

        [DataMember(Order = 1)]
        [XmlArray("Mappings")]
        [XmlArrayItem("ReferenceID")]
        public MdmIdList Mappings { get; set; }
    }
}