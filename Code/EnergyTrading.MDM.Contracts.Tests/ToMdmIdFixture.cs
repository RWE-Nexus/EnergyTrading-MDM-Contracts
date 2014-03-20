namespace EnergyTrading.Mdm.Contracts.Test
{
    using EnergyTrading.Mdm.Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ToMdmIdFixture
    {
        [Test]
        public void ReturnNullForNullMdmEntity()
        {
            SourceSystem entity = null;

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNullForZeroIdentifiers()
        {
            var entity = new SourceSystem();

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNullForNoNexusIdentifier()
        {
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());

            var candidate = entity.ToMdmId();

            Assert.IsNull(candidate);
        }

        [Test]
        public void ReturnNexusIdentifier()
        {
            var expected = new MdmId { Identifier = "1", IsMdmId = true };
            var entity = new SourceSystem { Identifiers = new MdmIdList { new MdmId(), expected } };

            var candidate = entity.ToMdmId();

            Assert.AreEqual(expected, candidate);
        }
    }
}