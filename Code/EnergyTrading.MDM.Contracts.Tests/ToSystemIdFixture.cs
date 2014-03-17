namespace RWEST.Nexus.MDM.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToSystemIdFixture
    {
        private const string SystemName = "Test";

        [TestMethod]
        public void ReturnNullForNullMdmEntity()
        {
            SourceSystem entity = null;

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForZeroIdentifiers()
        {
            var entity = new SourceSystem();

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForNoSystemIdentifier()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new MdmId { Identifier = "1", SystemName = SystemName };
            var entity = new SourceSystem { Identifiers = new MdmIdList { new MdmId(), expected } };

            var candidate = entity.ToSystemId(SystemName);

            Assert.AreEqual(expected, candidate);
        }
    }
}