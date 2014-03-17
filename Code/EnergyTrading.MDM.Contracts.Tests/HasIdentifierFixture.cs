namespace RWEST.Nexus.MDM.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HasIdentifierFixture
    {
        [TestMethod]
        public void ShouldReturnTrueIfPresent()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });
            entity.Identifiers.Add(new MdmId { SystemName = "B", Identifier = "B" });

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsTrue(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresent()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseOnNullEntity()
        {
            SourceSystem entity = null;

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseOnNullIdentifier()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });

            MdmId value = null;

            Assert.IsFalse(entity.HasIdentifier(value));
        }
    }
}