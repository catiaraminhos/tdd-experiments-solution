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

        [Test]
        public void TemplateWithTwoVariables()
        {
            var segments = Parse("${a}:${b}:${c}");
            AssertSegments(segments, "${a}", ":", "${b}", ":", "${c}");
        }

        private List<string> Parse (string template)
        {
            return new TemplateParse().Parse(template);
        }

        private void AssertSegments<T> (List<T> actual, params T[] expected)
        {
            Assert.That(actual.Count, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EqualTo(expected.ToList()));
        }
    }
}
