using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using RfsForChrome.Service;

namespace RfsForChrome.Test
{
    [TestFixture]
    public class OrderAndModelIncidentsTest
    {
        private XDocument _document;
        
        [SetUp]
        public void SetUpTests()
        {
            _document = XDocument.Load(File.OpenRead("TestData.xml"));
        }

        [Test]
        public void ShouldGetCouncilAreaAsKempsey()
        {
            var orderer = new OrderAndModelIncidents();
            var model = orderer.CreateModel(_document);
            var incident = model.ElementAt(1);
            Assert.That(incident.CouncilArea, Is.EqualTo("Kempsey"));
        }

        [Test]
        public void ShouldGetStatusAsOutOfControl()
        {
            var orderer = new OrderAndModelIncidents();
            var model = orderer.CreateModel(_document);
            var incident = model.ElementAt(1);
            Assert.That(incident.Status, Is.EqualTo("out of control"));
        }

        [Test]
        public void ShouldGetSize()
        {
            var orderer = new OrderAndModelIncidents();
            var model = orderer.CreateModel(_document);
            var incident = model.ElementAt(1);
            Assert.That(incident.Size, Is.EqualTo("0 ha"));
        }
    }
}