using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TemplateEngine
{
    public class TemplateParse
    {
        public List<ISegment> ParseSegments(string templateText)
        {
            var segments = new List<ISegment>();
            var index = CollectSegments(segments, templateText);
            AddTail(segments, templateText, index);
            AddEmptyStringIfTemplateWasEmpty(segments);
            return segments;
        }

        private int CollectSegments(List<ISegment> segments, string source)
        {
            var pattern = "\\$\\{[^}]*\\}";
            var match = Regex.Match(source, pattern);

            int index = 0;
            while (match.Success)
            {
                AddPrecedingPlainText(segments, source, match, index);
                AddVariable(segments, source, match);
                index = match.Index + match.Length;
                match = match.NextMatch();
            }

            return index;
        }

        private void AddTail(List<ISegment> segments, string templateText, int index)
        {
            if (index < templateText.Length)
            {
                string text = templateText.Substring(index);
                segments.Add(new PlainText(text));
            }
        }

        private void AddEmptyStringIfTemplateWasEmpty(List<ISegment> segments)
        {
            if (segments.Count == 0)
            {
                segments.Add(new PlainText(""));
            }
        }

        private void AddPrecedingPlainText(List<ISegment> segments, string source, Match match, int index)
        {
            if (index != match.Index)
            {
                string text = source[index..match.Index];
                segments.Add(new PlainText(text));
            }
        }

        private void AddVariable(List<ISegment> segments, string source, Match match)
        {
            string variableName = source.Substring(match.Index + 2, match.Length - 3);
            segments.Add(new Variable(variableName));
        }
    }
}
