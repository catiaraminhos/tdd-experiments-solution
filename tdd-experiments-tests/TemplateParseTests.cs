using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class TemplateParseTests
    {
        [Test]
        public void EmptyTemplateParsesAsEmptyString()
        {
            var segments = Parse("");
            AssertSegments(segments, new PlainText(""));
        }

        [Test]
        public void TemplateWithOnlyPlainText()
        {
            var segments = Parse("plain text only");
            AssertSegments(segments, new PlainText("plain text only"));
        }

        [Test]
        public void ParsingTemplateIntoSegmentObjects()
        {
            var segments = Parse("a ${b} c ${d}");
            AssertSegments(segments, new PlainText("a "), new Variable("b"),
                new PlainText(" c "), new Variable("d"));
        }

        private List<ISegment> Parse(string template)
        {
            return new TemplateParse().ParseSegments(template);
        }

        private void AssertSegments<T>(List<T> actual, params T[] expected)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EqualTo(expected.ToList()));
        }
    }
}
