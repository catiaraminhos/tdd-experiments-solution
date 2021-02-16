using NUnit.Framework;
using System.Collections.Generic;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class VariableSegmentTests
    {
        [Test]
        public void VariableEvaluatesToItsValue()
        {
            var variables = new Dictionary<string, string>();
            string name = "myvar";
            string value = "myvalue";
            variables.Add(name, value);
            Assert.That(new Variable(name).Evaluate(variables), Is.EqualTo(value));
        }
    }
}
