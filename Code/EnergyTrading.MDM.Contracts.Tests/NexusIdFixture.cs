namespace EnergyTrading.Mdm.Contracts.Test
{
    using System;

    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class MdmIdFixture
    {
        [Test]
        public void ReturnsNumericIdentifierValue()
        {
            var entityId = new EntityId { Identifier = new MdmId { Identifier = "3" } };

            var candidate = entityId.MdmId();
            Assert.IsTrue(candidate.HasValue);
            Assert.AreEqual(3, candidate.Value);
        }

        [Test]
        public void ReturnsZeroForNonNumericIdentifierValue()
        {
            var entityId = new EntityId { Identifier = new MdmId { Identifier = "A" } };

            var candidate = entityId.MdmId();
            Assert.IsTrue(candidate.HasValue);
            Assert.AreEqual(0, candidate.Value);
        }

        [Test]
        public void ReturnNullForNullEntityId()
        {
            EntityId entityId = null;

            var candidate = entityId.MdmId();
            Assert.IsFalse(candidate.HasValue);
        }

        [Test]
        public void ReturnNullForNullEntityIdIdentifier()
        {
            var entityId = new EntityId();

            var candidate = entityId.MdmId();
            Assert.IsFalse(candidate.HasValue);
        }

        [Test]
        public void ToStringDisplaysSystemAndIdentifier()
        {
            var value = new MdmId { SystemName = "CME", Identifier = "MFF" };

            Assert.AreEqual("CME/MFF", value.ToString());
        }

        [Test]
        public void NotEqualOnNull()
        {
            var value = new MdmId { SystemName = "CME", Identifier = "MFF" };

            Assert.IsFalse(value.Equals(null));
        }

        [Test]
        public void EqualOnSystemNameIdentifier()
        {
            var value = new MdmId
            {
                SystemName = "CME",
                Identifier = "MFF",
                IsMdmId = true,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5)
            };
            var candidate = new MdmId { SystemName = "CME", Identifier = "MFF" };

            Assert.IsTrue(value.Equals(candidate));
        }
    }
}