using System.Collections.Generic;

namespace TemplateEngine
{
    public class TemplateParse
    {
        public List<string> Parse(string templateText)
        {
            var parsedTemplate = new List<string>();
            parsedTemplate.Add(templateText);
            return parsedTemplate;
        }
    }
}
