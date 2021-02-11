using NUnit.Framework;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class TemplateTests
    {
        private Template template;


        [SetUp]
        public void SetUp()
        {
            template = new Template("${one}, ${two}, ${three}");
            template.Set("one", "1");
            template.Set("two", "2");
            template.Set("three", "3");
        }


        [Test]
        public void MultipleVariables()
        {
            AssertTemplateEvaluatesTo("1, 2, 3");
        }

        [Test]
        public void UnknownVariablesAreIgnored()
        {
            template.Set("doesnotexist", "whatever");
            AssertTemplateEvaluatesTo("1, 2, 3");
        }


        [Test]
        public void MissingValueRaisesException()
        {
            Assert.Throws<MissingValueException>(() => new Template("${foo}").Evaluate());
        }


        private void AssertTemplateEvaluatesTo(string expected)
        {
            Assert.That(template.Evaluate(), Is.EqualTo(expected));
        }
    }
}
