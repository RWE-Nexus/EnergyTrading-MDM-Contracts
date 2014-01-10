namespace RWEST.Nexus.MDM.Contracts.Test
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SystemIdFixture
    {
        [TestMethod]
        public void ReturnNullIfEntityNull()
        {
            IMdmEntity value = null;

            var candidate = value.SystemId();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnValueForEntityIfSystemFound()
        {
            var expected = new NexusId { SystemName = "A", Identifier = "A" };
            var entity = new Broker();
            entity.Identifiers.Add(new NexusId());
            entity.Identifiers.Add(expected);

            var candidate = entity.SystemId("A");
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifiersNull()
        {
            IList<NexusId> value = null;

            var candidate = value.SystemId();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifierCountZero()
        {
            var identifiers = new List<NexusId>();

            var candidate = identifiers.SystemId();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnValueIfSystemFound()
        {
            var expected = new NexusId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<NexusId> { new NexusId(), expected };

            var candidate = identifiers.SystemId("A");
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnNullIfSystemNotFound()
        {
            var expected = new NexusId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<NexusId> { new NexusId(), expected };

            var candidate = identifiers.SystemId("B");
            Assert.IsNull(candidate);
        }
    }
}