using NUnit.Framework;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class TemplateTests
    {
        [Test]
        public void OneVariable()
        {
            Template template = new Template("Hello, ${name}");
            template.Set("name", "Reader");
            Assert.That(template.Evaluate(), Is.EqualTo("Hello, Reader"));
        }


        [Test]
        public void DifferentTemplate()
        {
            Template template = new Template("Hi, ${name}");
            template.Set("name", "John");
            Assert.That(template.Evaluate(), Is.EqualTo("Hi, John"));
        }


        [Test]
        public void MultipleVariables()
        {
            Template template = new Template("${one}, ${two}, ${three}");
            template.Set("one", "1");
            template.Set("two", "2");
            template.Set("three", "3");
            Assert.That(template.Evaluate(), Is.EqualTo("1, 2, 3"));
        }

        [Test]
        public void UnknownVariablesAreIgnored()
        {
            Template template = new Template("Hello, ${name}");
            template.Set("name", "Reader");
            template.Set("doesnotexist", "Hi");
            Assert.That(template.Evaluate(), Is.EqualTo("Hello, Reader"));
        }
    }
}
