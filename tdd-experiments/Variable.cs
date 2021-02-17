using System.Collections.Generic;

namespace TemplateEngine
{
    public class Variable : ISegment
    {
        private string name;

        public Variable(string name)
        {
            this.name = name;
        }

        public string Evaluate(Dictionary<string, string> variables)
        {
            if (!variables.ContainsKey(name))
            {
                throw new MissingValueException(
                    "No value for ${" + name + "}");
            }
            
            return variables[name];
        }

        public override bool Equals(object other)
        {
            return name.Equals(((Variable)other).name);
        }
    }
}
