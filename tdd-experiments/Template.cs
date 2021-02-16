using System.Collections.Generic;
using System.Text;

namespace TemplateEngine
{
    public class Template
    {
        private string templateText;

        private Dictionary<string, string> variables;

        public Template(string templateText)
        {
            this.templateText = templateText;
            this.variables = new Dictionary<string, string>();
        }

        public void Set(string variable, string value)
        {
            this.variables[variable] = value;
        }

        public string Evaluate()
        {
            var parser = new TemplateParse();
            var segments = parser.ParseSegments(this.templateText);
            return Concatenate(segments);
        }

        private string Concatenate(List<ISegment> segments)
        {
            var result = new StringBuilder();
            foreach (ISegment segment in segments)
            {
                result.Append(segment.Evaluate(this.variables));
            }

            return result.ToString();
        }
    }
}
