using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    class TemplateParseTests
    {
        [Test]
        public void EmptyTemplateParsesAsEmptyString()
        {
            var segments = Parse("");
            AssertSegments(segments, "");
        }

        [Test]
        public void TemplateWithOnlyPlainText()
        {
            var segments = Parse("plain text only");
            AssertSegments(segments, "plain text only");
        }

        private List<string> Parse (string template)
        {
            return new TemplateParse().Parse(template);
        }

        private void AssertSegments<T> (List<T> actual, params T[] expected)
        {
            Assert.That(expected.Length, Is.EqualTo(actual.Count));
            Assert.That(expected.ToList(), Is.EqualTo(actual));
        }
    }
}
