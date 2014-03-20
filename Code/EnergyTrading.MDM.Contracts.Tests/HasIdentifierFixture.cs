namespace EnergyTrading.Mdm.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class HasIdentifierFixture
    {
        [Test]
        public void ShouldReturnTrueIfPresent()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });
            entity.Identifiers.Add(new MdmId { SystemName = "B", Identifier = "B" });

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsTrue(entity.HasIdentifier(value));
        }

        [Test]
        public void ShouldReturnFalseIfNotPresent()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [Test]
        public void ShouldReturnFalseOnNullEntity()
        {
            SourceSystem entity = null;

            var value = new MdmId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [Test]
        public void ShouldReturnFalseOnNullIdentifier()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId { SystemName = "A", Identifier = "A" });

            MdmId value = null;

            Assert.IsFalse(entity.HasIdentifier(value));
        }
    }
}