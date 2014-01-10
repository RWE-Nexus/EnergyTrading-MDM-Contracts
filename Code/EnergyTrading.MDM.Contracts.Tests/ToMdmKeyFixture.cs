namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

    [TestClass]
    public class ToMdmKeyFixture
    {
        [TestMethod]
        public void ReturnZeroForNullMdmEntity()
        {
            Commodity entity = null;

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForZeroIdentifiers()
        {
            var entity = new Commodity();

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForNoNexusIdentifier()
        {
            var entity = new Commodity();
            entity.Identifiers.Add(new NexusId());

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new NexusId { Identifier = "1", IsNexusId = true };
            var entity = new Commodity { Identifiers = new NexusIdList { new NexusId(), expected } };

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(1, candidate);
        }
    }
}