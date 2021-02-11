using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            this.variables.Add(variable, value);
        }

        public string Evaluate()
        {
            string templateResult = this.templateText;

            foreach(KeyValuePair<string, string> variable in this.variables)
            {
                string variableNameRegex = "\\$\\{" + variable.Key + "\\}";
                templateResult = Regex.Replace(templateResult, variableNameRegex , variable.Value);
            }

            return templateResult;
        }
    }
}
