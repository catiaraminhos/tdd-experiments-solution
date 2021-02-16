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
            if (!variables.ContainsKey(this.name))
            {
                throw new MissingValueException(
                    "No value for ${" + this.name + "}");
            }
            
            return variables[this.name];
        }

        public override bool Equals(object other)
        {
            return this.name.Equals(((Variable)other).name);
        }
    }
}
