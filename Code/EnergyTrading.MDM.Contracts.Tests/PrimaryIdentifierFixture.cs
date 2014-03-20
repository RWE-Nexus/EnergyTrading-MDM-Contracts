namespace EnergyTrading.Mdm.Contracts.Test
{
    using System.Collections.Generic;

    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class PrimaryIdentifierFixture
    {
        [Test]
        public void ReturnNullIfEntityNull()
        {
            IMdmEntity entity = null;

            var candidate = entity.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnOriginatingIdentifierForEntityIfPresent()
        {
            var expected = new MdmId { SourceSystemOriginated = true };

            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());
            entity.Identifiers.Add(expected);

            var candidate = entity.PrimaryIdentifier();
            Assert.AreSame(expected, candidate);
        }

        [Test]
        public void ReturnNullIfIdentifiersNull()
        {
            List<MdmId> identifiers = null;

            var candidate = identifiers.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNullIfIdentifierCountZero()
        {
            var identifiers = new List<MdmId>();

            var candidate = identifiers.PrimaryIdentifier();
            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnOriginatingIdentifierIfPresent()
        {
            var expected = new MdmId { SourceSystemOriginated = true };

            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.PrimaryIdentifier();
            Assert.AreSame(expected, candidate);
        }

        [Test]
        public void ReturnSystemIdentifierIfPresent()
        {
            var expected = new MdmId { SystemName = "A"};

            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.PrimaryIdentifier("A");
            Assert.AreSame(expected, candidate);
        }

        [Test]
        public void ReturnFirstIdentiiferIfOtherRulesFail()
        {
            var expected = new MdmId { SystemName = "A" };

            var identifiers = new List<MdmId> { expected, new MdmId() };

            var candidate = identifiers.PrimaryIdentifier("B");
            Assert.AreSame(expected, candidate);
        }
    }
}