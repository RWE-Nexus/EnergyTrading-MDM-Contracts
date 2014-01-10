namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

    [TestClass]
    public class HasIdentifierFixture
    {
        [TestMethod]
        public void ShouldReturnTrueIfPresent()
        {
            var entity = new Broker();
            entity.Identifiers.Add(new NexusId { SystemName = "A", Identifier = "A" });
            entity.Identifiers.Add(new NexusId { SystemName = "B", Identifier = "B" });

            var value = new NexusId { SystemName = "B", Identifier = "B" };

            Assert.IsTrue(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotPresent()
        {
            var entity = new Broker();
            entity.Identifiers.Add(new NexusId { SystemName = "A", Identifier = "A" });

            var value = new NexusId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseOnNullEntity()
        {
            Broker entity = null;

            var value = new NexusId { SystemName = "B", Identifier = "B" };

            Assert.IsFalse(entity.HasIdentifier(value));
        }

        [TestMethod]
        public void ShouldReturnFalseOnNullIdentifier()
        {
            var entity = new Broker();
            entity.Identifiers.Add(new NexusId { SystemName = "A", Identifier = "A" });

            NexusId value = null;

            Assert.IsFalse(entity.HasIdentifier(value));
        }
    }
}