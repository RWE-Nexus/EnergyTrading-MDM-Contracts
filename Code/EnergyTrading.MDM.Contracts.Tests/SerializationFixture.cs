namespace EnergyTrading.Mdm.Contracts.Test
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;

    using NUnit.Framework;

    [TestFixture]
    public class SerializationFixture
    {
        public static string LoadEmbeddedResource(string resourceName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return stream == null ? null : new StreamReader(stream).ReadToEnd();
        }

        public static T DeserializeDataContractXml<T>(string contents, Type[] types = null)
        {
            T result;

            using (var reader = XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(new StringReader(contents))))
            {
                var serializer = new DataContractSerializer(typeof(T));
                result = (T)serializer.ReadObject(reader);
            }
            return result;
        }

        [Test]
        public void DeSerializeOldServiceResults()
        {
            var xmlText = LoadEmbeddedResource("EnergyTrading.Mdm.Contracts.Test.OldMdmSourceSystemList.xml");
            var result = DeserializeDataContractXml<SourceSystemList>(xmlText);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<SourceSystemList>());
            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Details.Name, Is.EqualTo("Endur"));
            Assert.That(result[0].MdmSystemData.StartDate, Is.EqualTo(DateTime.Parse("1753-01-01T00:00:00")));
            Assert.That(result[0].MdmSystemData.EndDate, Is.EqualTo(DateTime.Parse("9999-12-31T00:00:00")));
            Assert.That(result[0].Identifiers.Count, Is.EqualTo(3));
            Assert.That(result[1].Identifiers.Count, Is.EqualTo(3));
            Assert.That(result[2].Identifiers.Count, Is.EqualTo(3));
            Assert.That(result[3].Identifiers.Count, Is.EqualTo(2));
            Assert.That(result[4].Identifiers.Count, Is.EqualTo(3));
            this.CheckMdmIdValues(result[0].Identifiers[0], "Nexus", "1", true);
            this.CheckMdmIdValues(result[0].Identifiers[1], "ADC", "Endur", false);
            this.CheckMdmIdValues(result[0].Identifiers[2], "Spreadsheet", "5", false);
        }

        private void CheckMdmIdValues(MdmId id, string name, string identifier, bool ismdmid)
        {
            Assert.That(id.SystemName, Is.EqualTo(name));
            Assert.That(id.Identifier, Is.EqualTo(identifier));
            Assert.That(id.IsMdmId, Is.EqualTo(ismdmid));
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
        }

        public static string DataContractSerialize<T>(T entity)
        {
            using (var stream = new Utf8StringWriter())
            {
                TextWriterDataContractSerialize(stream, entity);
                return stream.ToString();
            }
        }

        public static void TextWriterDataContractSerialize<T>(TextWriter textWriter, T entity, Type[] types = null)
        {
            using (var writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(textWriter, new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true, IndentChars = "  "})))
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(writer, entity);
                writer.Close();
            }
        }

        [Test]
        public void RoundTripStringObjectString()
        {
            var original = LoadEmbeddedResource("EnergyTrading.Mdm.Contracts.Test.OldMdmSourceSystemList.xml");
            var result = DataContractSerialize(DeserializeDataContractXml<SourceSystemList>(original));
            Assert.AreEqual(this.ReplaceNamespaceNames(original), this.ReplaceNamespaceNames(result));
        }

        private string ReplaceNamespaceNames(string original)
        {
            return Regex.Replace(original, "xmlns:.*=", "xmlns:replaced=");
        }
    }
}