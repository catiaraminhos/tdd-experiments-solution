using NUnit.Framework;
using System.Collections.Generic;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class PlainTextSegmentTests
    {
        [Test]
        public void PlainTextEvaluatesAsIs()
        {
            var variables = new Dictionary<string, string>();
            string text = "abc def";
            Assert.That(new PlainText(text).Evaluate(variables), Is.EqualTo(text));
        }
    }
}
