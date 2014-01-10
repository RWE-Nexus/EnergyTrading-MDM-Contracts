namespace RWEST.Nexus.MDM.Contracts.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

    [TestClass]
    public class NexusIdFixture
    {
        [TestMethod]
        public void ReturnsNumericIdentifierValue()
        {
            var entityId = new EntityId { Identifier = new NexusId { Identifier = "3" } };

            var candidate = entityId.NexusId();
            Assert.IsTrue(candidate.HasValue);
            Assert.AreEqual(3, candidate.Value);
        }

        [TestMethod]
        public void ReturnsZeroForNonNumericIdentifierValue()
        {
            var entityId = new EntityId { Identifier = new NexusId { Identifier = "A" } };

            var candidate = entityId.NexusId();
            Assert.IsTrue(candidate.HasValue);
            Assert.AreEqual(0, candidate.Value);
        }

        [TestMethod]
        public void ReturnNullForNullEntityId()
        {
            EntityId entityId = null;

            var candidate = entityId.NexusId();
            Assert.IsFalse(candidate.HasValue);
        }

        [TestMethod]
        public void ReturnNullForNullEntityIdIdentifier()
        {
            var entityId = new EntityId();

            var candidate = entityId.NexusId();
            Assert.IsFalse(candidate.HasValue);
        }

        [TestMethod]
        public void ToStringDisplaysSystemAndIdentifier()
        {
            var value = new NexusId { SystemName = "CME", Identifier = "MFF" };

            Assert.AreEqual("CME/MFF", value.ToString());
        }

        [TestMethod]
        public void NotEqualOnNull()
        {
            var value = new NexusId { SystemName = "CME", Identifier = "MFF" };

            Assert.IsFalse(value.Equals(null));
        }

        [TestMethod]
        public void EqualOnSystemNameIdentifier()
        {
            var value = new NexusId
            {
                SystemName = "CME",
                Identifier = "MFF",
                IsNexusId = true,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5)
            };
            var candidate = new NexusId { SystemName = "CME", Identifier = "MFF" };

            Assert.IsTrue(value.Equals(candidate));
        }
    }
}