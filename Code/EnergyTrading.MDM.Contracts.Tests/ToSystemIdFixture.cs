namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ToSystemIdFixture
    {
        private const string SystemName = "Test";

        [TestMethod]
        public void ReturnNullForNullMdmEntity()
        {
            Commodity entity = null;

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForZeroIdentifiers()
        {
            var entity = new Commodity();

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForNoSystemIdentifier()
        {
            var entity = new Commodity();
            entity.Identifiers.Add(new NexusId());

            var candidate = entity.ToSystemId(SystemName);

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new NexusId { Identifier = "1", SystemName = SystemName };
            var entity = new Commodity { Identifiers = new NexusIdList { new NexusId(), expected } };

            var candidate = entity.ToSystemId(SystemName);

            Assert.AreEqual(expected, candidate);
        }
    }
}