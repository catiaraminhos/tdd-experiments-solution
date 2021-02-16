using System.Collections.Generic;

namespace TemplateEngine
{
    public interface ISegment
    {
        string Evaluate(Dictionary<string, string> variables);
    }
}
