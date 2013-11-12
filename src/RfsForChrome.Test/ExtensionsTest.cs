using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RfsForChrome.Service.Extensions;

namespace RfsForChrome.Test
{
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void ShouldReturnAValidDate()
        {
            var sampleDate = "Tue, 12 Nov 2013 06:35:00 GMT";
            var date = sampleDate.MyToDateTime();
            Assert.That(date, Is.EqualTo(new DateTime(2013, 11, 12, 17, 35, 00)));
        }
    }
}
