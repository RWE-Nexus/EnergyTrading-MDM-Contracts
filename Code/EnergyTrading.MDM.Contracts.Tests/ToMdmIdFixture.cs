namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

    [TestClass]
    public class ToMdmIdFixture
    {
        [TestMethod]
        public void ReturnNullForNullMdmEntity()
        {
            Commodity entity = null;

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForZeroIdentifiers()
        {
            var entity = new Commodity();

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullForNoNexusIdentifier()
        {
            var entity = new Commodity();
            entity.Identifiers.Add(new NexusId());

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new NexusId { Identifier = "1", IsNexusId = true };
            var entity = new Commodity { Identifiers = new NexusIdList { new NexusId(), expected } };

            var candidate = entity.ToMdmId();

            Assert.AreEqual(expected, candidate);
        }
    }
}