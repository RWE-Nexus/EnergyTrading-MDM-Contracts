namespace EnergyTrading.Mdm.Contracts.Test
{
    using System.Collections.Generic;

    using EnergyTrading.Mdm.Contracts;

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
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var entity = new SourceSystem();
            entity.Identifiers.Add(new MdmId());
            entity.Identifiers.Add(expected);

            var candidate = entity.SystemId("A");
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifiersNull()
        {
            IList<MdmId> value = null;

            var candidate = value.SystemId();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnNullIfIdentifierCountZero()
        {
            var identifiers = new List<MdmId>();

            var candidate = identifiers.SystemId();
            Assert.IsNull(candidate);
        }

        [TestMethod]
        public void ReturnValueIfSystemFound()
        {
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.SystemId("A");
            Assert.AreSame(expected, candidate);
        }

        [TestMethod]
        public void ReturnNullIfSystemNotFound()
        {
            var expected = new MdmId { SystemName = "A", Identifier = "A" };
            var identifiers = new List<MdmId> { new MdmId(), expected };

            var candidate = identifiers.SystemId("B");
            Assert.IsNull(candidate);
        }
    }
}