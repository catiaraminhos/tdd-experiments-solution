using System.Collections.Generic;

namespace TemplateEngine
{
    public class PlainText : ISegment
    {
        private string text;

        public PlainText(string text)
        {
            this.text = text;
        }

        public string Evaluate(Dictionary<string, string> variables)
        {
            return text;
        }

        public override bool Equals(object other)
        {
            return text.Equals(((PlainText)other).text);
        }
    }
}
