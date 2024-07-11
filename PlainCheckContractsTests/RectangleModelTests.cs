using PlainCheckContracts.Dto;
using PlainCheckContracts.Models;

namespace PlainCheckContractsTests
{
    [TestFixture]
    public class RectangleModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

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
            Assert.That(()=> new RectangleModel(dots), Throws.Nothing);
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

    }
}