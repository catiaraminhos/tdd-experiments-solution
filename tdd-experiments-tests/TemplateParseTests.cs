using NUnit.Framework;
using System.Collections.Generic;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    class TemplateParseTests
    {
        [Test]
        public void EmptyTemplateParsesAsEmptyString()
        {
            var parse = new TemplateParse();
            List<string> segments = parse.Parse("");
            Assert.That(segments.Count, Is.EqualTo(1));
            Assert.That(segments[0], Is.EqualTo(""));
        }

        [Test]
        public void TemplateWithOnlyPlainText()
        {
            var parse = new TemplateParse();
            List<string> segments = parse.Parse("plain text only");
            Assert.That(segments.Count, Is.EqualTo(1));
            Assert.That(segments[0], Is.EqualTo("plain text only"));
        }
    }
}
