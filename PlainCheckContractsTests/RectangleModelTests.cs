using PlainCheckContracts.Dto;
using PlainCheckContracts.Models;

namespace PlainCheckContractsTests
{
    [TestFixture]
    public class RectangleModelTests
    {
        [TestCaseSource(nameof(_positiveSortedSourceLists))]
        public void RectangleVertexOrderCheckTest(List<DotModel> dots)
        {
            var model = new RectangleModel(dots);
            Assert.That(model.BottomLeftDot.X == 1);
            Assert.That(model.BottomLeftDot.Y == 1);
            Assert.That(model.BottomRightDot.X == 5);
            Assert.That(model.BottomRightDot.Y == 1);
            Assert.That(model.TopLeftDot.X == 1);
            Assert.That(model.TopLeftDot.Y == 3);
            Assert.That(model.TopRightDot.X == 5);
            Assert.That(model.TopRightDot.Y == 3);
        }

        [Test]
        public void RectangleValidateDotCountPositiveTest()
        {
            var dots = new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 1
                },
            };
            Assert.That(() => new RectangleModel(dots), Throws.Nothing);
        }

        [Test]
        public void RectangleValidateDotCountNegativeTest()
        {
            var dots = new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
            };
            Assert.That(() => new RectangleModel(dots), Throws.ArgumentException);
        }

        [Test]
        public void RectangleValidateDotEmptyNegativeTest()
        {
            var dots = new List<DotModel>();
            Assert.That(() => new RectangleModel(dots), Throws.ArgumentException);
        }

        [Test]
        public void RectangleValidateDotEqualsNegativeTest()
        {
            var dots = new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 1
                },
            };
            Assert.That(() => new RectangleModel(dots), Throws.ArgumentException);
        }

        [TestCaseSource(nameof(_positiveRectangleSourceLists))]
        public void RectangleValidateIsRectanglePositiveTest(List<DotModel> dots)
        {
            var model = new RectangleModel(dots);
            Assert.That(model.IsRectangle == true);
        }

        [TestCaseSource(nameof(_negativeRectangleSourceLists))]
        public void RectangleValidateIsRectangleNegativeTest(List<DotModel> dots)
        {
            var model = new RectangleModel(dots);
            Assert.That(model.IsRectangle == false);
        }

        private static readonly object[] _positiveSortedSourceLists = new object[]
        {
            new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 1
                },
            },
            new List<DotModel>
            {
                new DotModel
                {
                    X = 5, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 1, Y = 1
                },
            },
            new List<DotModel>
            {
                new DotModel
                {
                    X = 5, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
            },
            new List<DotModel>
            {
                new DotModel
                {
                    X = 5, Y = 1
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
            },
            new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 1
                },
            },
        };

        private static readonly object[] _positiveRectangleSourceLists = new object[]
        {
            new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 1
                },
                new DotModel
                {
                    X = 1, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 3
                },
                new DotModel
                {
                    X = 5, Y = 1
                },
            },
        };
        private static readonly object[] _negativeRectangleSourceLists = new object[]
       {
            new List<DotModel>
            {
                new DotModel
                {
                    X = 1, Y = 2
                },
                new DotModel
                {
                    X = 4, Y = 4.5F
                },
                new DotModel
                {
                    X = 5.5F, Y = 3.5F
                },
                new DotModel
                {
                    X = 2.5F, Y = 0
                },
            },
       };
    }
}