using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TemplateEngine
{
    public class TemplateParse
    {
        public List<string> Parse(string templateText)
        {
            var segments = new List<string>();
            var index = CollectSegments(segments, templateText);
            AddTail(segments, templateText, index);
            AddEmptyStringIfTemplateWasEmpty(segments);
            return segments;
        }

        public List<ISegment> ParseSegments(string template)
        {
            var segments = new List<ISegment>();
            var segmentsStrings = Parse(template);
            foreach (string segmentString in segmentsStrings)
            {
                if (Template.IsVariable(segmentString))
                {
                    string variableName = segmentString[2..(segmentString.Length - 1)];
                    segments.Add(new Variable(variableName));
                }
                else
                {
                    segments.Add(new PlainText(segmentString));
                }
            }

            return segments;
        }

        private int CollectSegments(List<string> segs, string src)
        {
            var pattern = "\\$\\{[^}]*\\}";
            var match = Regex.Match(src, pattern);

            int index = 0;
            while (match.Success)
            {
                AddPrecedingPlainText(segs, src, match, index);
                AddVariable(segs, src, match);
                index = match.Index + match.Length;
                match = match.NextMatch();
            }

            return index;
        }

        private void AddTail(List<string> segs, string templateText, int index)
        {
            if (index < templateText.Length)
            {
                segs.Add(templateText.Substring(index));
            }
        }

        private void AddEmptyStringIfTemplateWasEmpty(List<string> segs)
        {
            if (segs.Count == 0)
            {
                segs.Add("");
            }
        }

        private void AddPrecedingPlainText(List<string> segs, string src, Match match, int index)
        {
            if (index != match.Index)
            {
                segs.Add(src[index..match.Index]);
            }
        }

        private void AddVariable(List<string> segs, string src, Match match)
        {
            segs.Add(src.Substring(match.Index, match.Length));
        }
    }
}
