using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using RfsForChrome.Service;
using RfsForChrome.Service.Models;

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

        [Test]
        public void ShouldParseTimeFromDescriptionString()
        {
            var orderer = new OrderAndModelIncidents();
            var model = orderer.CreateModel(_document);
            var incident = model.ElementAt(1);
            Assert.That(incident.LastUpdated, Is.EqualTo(new DateTime(2013, 11, 29, 20, 04,0)));
        }

//        [Test]
//        public void ShouldGetLocation()
//        {
//            var orderer = new OrderAndModelIncidents();
//            var model = orderer.CreateModel(_document);
//            var incident = model.ElementAt(1);
//            Assert.That(incident.Location, Is.EqualTo("Pacific Hwy xs Cooks Lane Clybucca"));
//        }
    }
}