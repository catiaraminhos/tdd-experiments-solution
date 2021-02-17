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

        private void AddTail(List<ISegment> segs, string templateText, int index)
        {
            if (index < templateText.Length)
            {
                string text = templateText.Substring(index);
                segs.Add(new PlainText(text));
            }
        }

        private void AddEmptyStringIfTemplateWasEmpty(List<ISegment> segs)
        {
            if (segs.Count == 0)
            {
                segs.Add(new PlainText(""));
            }
        }

        private void AddPrecedingPlainText(List<ISegment> segs, string src, Match match, int index)
        {
            if (index != match.Index)
            {
                string text = src[index..match.Index];
                segs.Add(new PlainText(text));
            }
        }

        private void AddVariable(List<ISegment> segs, string src, Match match)
        {
            string variableName = src.Substring(match.Index + 2, match.Length - 3);
            segs.Add(new Variable(variableName));
        }
    }
}
