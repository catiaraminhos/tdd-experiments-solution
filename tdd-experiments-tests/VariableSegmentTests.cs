using NUnit.Framework;
using System.Collections.Generic;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class VariableSegmentTests
    {
        private Dictionary<string, string> variables;

        [SetUp]
        public void SetUp()
        {
            variables = new Dictionary<string, string>();
        }

        [Test]
        public void VariableEvaluatesToItsValue()
        {
            string name = "myvar";
            string value = "myvalue";
            variables.Add(name, value);
            Assert.That(new Variable(name).Evaluate(variables), Is.EqualTo(value));
        }

        [Test]
        public void MissingVariableRaisesException()
        {
            string name = "myvar";
            var missingValueException =
                Assert.Throws<MissingValueException>(() => new Variable(name).Evaluate(variables));
            Assert.That(missingValueException.Message, Is.EqualTo("No value for ${" + name + "}"));
        }
    }
}
