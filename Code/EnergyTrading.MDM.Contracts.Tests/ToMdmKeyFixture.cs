namespace EnergyTrading.Mdm.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToMdmKeyFixture
    {
        [TestMethod]
        public void ReturnZeroForNullMdmEntity()
        {
            SourceSystem entity = null;

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForZeroIdentifiers()
        {
            var entity = new SourceSystem();

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnZeroForNoNexusIdentifier()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(0, candidate);
        }

        [TestMethod]
        public void ReturnNexusIdentifier()
        {
            var expected = new MdmId { Identifier = "1", IsMdmId = true };
            var entity = new SourceSystem { Identifiers = new MdmIdList { new MdmId(), expected } };

            var candidate = entity.ToMdmKey();

            Assert.AreEqual(1, candidate);
        }
    }
}