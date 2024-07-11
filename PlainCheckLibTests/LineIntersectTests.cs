using PlainCheckContracts.Interfaces;
using PlainCheckContracts.Models;
using PlainCheckLib.Implementations;

namespace PlainCheckLibTests
{
    [TestFixture]
    public class LineIntersectTests
    {
        [TestCaseSource(nameof(_positiveIntersectLines))]
        public void LineIntersectPositiveTest(DotModel dot1, DotModel dot2, DotModel dot3, DotModel dot4)
        {
            ILineIntersect lineIntersect = new LineIntersect();
            
            Assert.That(lineIntersect.LineIntersectCheck(dot1, dot2, dot3, dot4) == true);
        }

        [TestCaseSource(nameof(_negativeIntersectLines))]
        public void LineIntersectNegativeTest(DotModel dot1, DotModel dot2, DotModel dot3, DotModel dot4)
        {
            ILineIntersect lineIntersect = new LineIntersect();

            Assert.That(lineIntersect.LineIntersectCheck(dot1, dot2, dot3, dot4) == false);
        }

        private static readonly object[] _positiveIntersectLines = new object[]
        {
            new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
                new DotModel
                {
                    X = 2, Y = 4
                },
                new DotModel
                {
                    X = 12, Y = 3
                },
            },
            new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
            },
             new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
                new DotModel
                {
                    X = 232, Y = 4532
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
            },
             new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
            }
        };

        private static readonly object[] _negativeIntersectLines = new object[]
        {
            new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 0, Y = 0
                },
            },
             new object[]
            {
                new DotModel
                {
                    X = 2, Y = 2
                },
                new DotModel
                {
                    X = 12, Y = 8
                },
                new DotModel
                {
                    X = 1.999999F, Y = 1.999999F
                },
                new DotModel
                {
                    X = 0, Y = 0
                },
            },
        };
    }
}