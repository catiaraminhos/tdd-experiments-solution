using NUnit.Framework;
using System.Diagnostics;
using TemplateEngine;

namespace TemplateTests
{
    [TestFixture]
    public class TemplatePerformanceTests
    {
        private Template template;


        [SetUp]
        public void SetUp()
        {
            template = new Template("Far far ${one}, behind the ${two} mountains, " +
                "far ${three} the countries Vokalia and Consonantia, there live the blind texts. " +
                "Separated they live ${four} Bookmarksgrove ${five} ${six} the ${seven} of the Semantics, " +
                "a large language ${eight}. A small river named Duden ${nine} by their ${ten} and " +
                "supplies it ${eleven} ${twelve} necessary ${thirteen}. It is a ${fourteen} country, " +
                "in which roasted parts of ${fifteen} fly into your mouth. Even the ${sixteen} " +
                "${eighteen} has no control about the blind texts it is an almost ${nineteen} life " +
                "One day ${twenty} a small line of blind text by the name of Lorem Ipsum decided to");

            template.Set("one", "awayawayawayaway");
            template.Set("two", "wordwordwordword");
            template.Set("three", "fromfromfromfrom");
            template.Set("four", "ininininininin");
            template.Set("five", "rightrightrightrightright");
            template.Set("six", "atatatatatatatatatatatatat");
            template.Set("seven", "coastcoastcoastcoastcoast");
            template.Set("eight", "oceanoceanoceanoceanocean");
            template.Set("nine", "flowsflowsflowsflows");
            template.Set("ten", "placeplaceplaceplaceplace");
            template.Set("eleven", "withwithwithwithwithwith");
            template.Set("twelve", "thethethethethethethethe");
            template.Set("thirteen", "regelialiaregelialia");
            template.Set("fourteen", "paradisematicparadisematic");
            template.Set("fifteen", "sentencessentences");
            template.Set("sixteen", "all-powerfulall-powerful");
            template.Set("eighteen", "PointingPointing");
            template.Set("nineteen", "unorthographicunorthographic");
            template.Set("twenty", "howeverhoweverhowever");
        }


        [Test]
        public void TemplateWith100WordsAnd20Variables()
        {
            long expectedMaxMilliseconds = 200L;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            template.Evaluate();
            stopWatch.Stop();
            Assert.That(stopWatch.ElapsedMilliseconds, Is.AtMost(expectedMaxMilliseconds));
        }
    }
}
