namespace RWEST.Nexus.MDM.Contracts.Test
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PrimaryIdentifierFixture
    {
        [TestMethod]
        public void ReturnNullIfEntityNull()
        {
            IMdmEntity entity = null;

            var candidate = entity.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnOriginatingIdentifierForEntityIfPresent()
        {
            var expected = new NexusId { SourceSystemOriginated = true };

            var entity = new Broker();
            entity.Identifiers.Add(new NexusId());
            entity.Identifiers.Add(expected);

            var candidate = entity.PrimaryIdentifier();
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifiersNull()
        {
            List<NexusId> identifiers = null;

            var candidate = identifiers.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifierCountZero()
        {
            var identifiers = new List<NexusId>();

            var candidate = identifiers.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnOriginatingIdentifierIfPresent()
        {
            var expected = new NexusId { SourceSystemOriginated = true };

            var identifiers = new List<NexusId> { new NexusId(), expected };

            var candidate = identifiers.PrimaryIdentifier();
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnSystemIdentifierIfPresent()
        {
            var expected = new NexusId { SystemName = "A"};

            var identifiers = new List<NexusId> { new NexusId(), expected };

            var candidate = identifiers.PrimaryIdentifier("A");
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnFirstIdentiiferIfOtherRulesFail()
        {
            var expected = new NexusId { SystemName = "A" };

            var identifiers = new List<NexusId> { expected, new NexusId() };

            var candidate = identifiers.PrimaryIdentifier("B");
            Assert.AreSame(expected, candidate);
        }
    }
}