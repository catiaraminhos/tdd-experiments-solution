using NPOI.Util;

namespace TemplateEngine
{
    public class MissingValueException: RuntimeException
    {
        public MissingValueException(string message): base(message)
        {
        }
    }
}
