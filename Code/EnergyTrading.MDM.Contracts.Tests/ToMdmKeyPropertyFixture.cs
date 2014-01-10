namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

    [TestClass]
    public class ToMdmKeyPropertyFixture
    {
        [TestMethod]
        public void ReturnZeroForNullMdmEntity()
        {
            Market entity = null;

            var candidate = entity.ToMdmKey(x => x.Details.Commodity);

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForNullDetails()
        {
            var entity = new Market { Details = null };

            var candidate = entity.ToMdmKey(x => x.Details.Commodity);

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForNullForeignKey()
        {
            var entity = new Market();

            var candidate = entity.ToMdmKey(x => x.Details.Commodity);

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnForeignKeyValue()
        {
            var expected = new NexusId { Identifier = "1", IsNexusId = true };
            var entity = new Market
            {
                Details = new MarketDetails { Commodity = expected.ToEntityId() }
            };

            var candidate = entity.ToMdmKey(x => x.Details.Commodity);

            Assert.AreEqual(1, candidate);
        }
    }
}
