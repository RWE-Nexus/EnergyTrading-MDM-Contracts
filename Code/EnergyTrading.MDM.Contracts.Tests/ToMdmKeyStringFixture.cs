namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToMdmKeyStringFixture
    {
        [TestMethod]
        public void ReturnNullForNullMdmEntity()
        {
            Commodity entity = null;

            var candidate = entity.ToMdmKeyString();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForZeroIdentifiers()
        {
            var entity = new Commodity();

            var candidate = entity.ToMdmKeyString();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForNoNexusIdentifier()
        {
            var entity = new Commodity();
            entity.Identifiers.Add(new NexusId());

            var candidate = entity.ToMdmKeyString();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new NexusId { Identifier = "1", IsNexusId = true };
            var entity = new Commodity { Identifiers = new NexusIdList { new NexusId(), expected } };

            var candidate = entity.ToMdmKeyString();

            Assert.AreEqual("1", candidate);
        }
    }
}
