namespace RWEST.Nexus.MDM.Contracts.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RWEST.Nexus.MDM.Contracts;

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
            var value = new EntityId { Identifier = new NexusId { Identifier = "A" } };

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
        public void ReturnNullIfNexusIdIsNull()
        {
            NexusId value = null;

            var candidate = value.ToIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnIdentifierOfNexusId()
        {
            var value = new NexusId { Identifier = "A" };

            var candidate = value.ToIdentifier();
            Assert.AreEqual("A", candidate);
        }
    }
}