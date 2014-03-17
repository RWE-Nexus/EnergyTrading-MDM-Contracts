namespace EnergyTrading.Mdm.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToIdentifierFixture
    {
        [TestMethod]
        public void ReturnNullIfEntityIdIsNull()
        {
            EntityId value = null;

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnIdentifierOfEntityId()
        {
            var value = new EntityId { Identifier = new MdmId { Identifier = "A" } };

            var candidate = value.ToIdentifier();
            Assert.AreEqual("A", candidate);
        }

        [TestMethod]
        public void ReturnNullIfEntityIdIdentifierIsNull()
        {
            var value = new EntityId();

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullIfMdmIdIsNull()
        {
            MdmId value = null;

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnIdentifierOfMdmId()
        {
            var value = new MdmId { Identifier = "A" };

            var candidate = value.ToIdentifier();
            Assert.AreEqual("A", candidate);
        }
    }
}