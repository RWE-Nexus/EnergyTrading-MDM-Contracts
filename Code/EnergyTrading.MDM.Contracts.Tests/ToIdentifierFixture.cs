namespace EnergyTrading.Mdm.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ToIdentifierFixture
    {
        [Test]
        public void ReturnNullIfEntityIdIsNull()
        {
            EntityId value = null;

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnIdentifierOfEntityId()
        {
            var value = new EntityId { Identifier = new MdmId { Identifier = "A" } };

            var candidate = value.ToIdentifier();
            Assert.AreEqual("A", candidate);
        }

        [Test]
        public void ReturnNullIfEntityIdIdentifierIsNull()
        {
            var value = new EntityId();

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNullIfMdmIdIsNull()
        {
            MdmId value = null;

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnIdentifierOfMdmId()
        {
            var value = new MdmId { Identifier = "A" };

            var candidate = value.ToIdentifier();
            Assert.AreEqual("A", candidate);
        }
    }
}