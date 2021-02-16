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
            var segments = parser.Parse(this.templateText);
            var result = new StringBuilder();
            foreach (string segment in segments)
            {
                Append(segment, result);
            }

            return result.ToString();
        }

        private void Append(string segment, StringBuilder result)
        {
            if (segment.StartsWith("${") && segment.EndsWith("}"))
            {
                string variable = segment[2..(segment.Length - 1)];
                if (!this.variables.ContainsKey(variable))
                {
                    throw new MissingValueException("No value for " + segment);
                }

                result.Append(this.variables[variable]);
            } else
            {
                result.Append(segment);
            }
        }
    }
}
