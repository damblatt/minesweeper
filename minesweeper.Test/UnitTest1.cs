using minesweeper.Model;

namespace minesweeper.Test
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void TesrtReadA12()
        {
            var input = "A12";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);

            Assert.IsTrue(isCreated);
            Assert.AreEqual(0, coordinate.X);
            Assert.AreEqual(11, coordinate.Y);
        }


        [TestMethod]
        public void TesrtReada12()
        {
            var input = "a12";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);

            Assert.IsTrue(isCreated);
            Assert.AreEqual(0, coordinate.X);
            Assert.AreEqual(11, coordinate.Y);
        }


        [TestMethod]
        public void TesrtReadE7()
        {
            var input = "E7";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);

            Assert.IsTrue(isCreated);
            Assert.AreEqual(4, coordinate.X);
            Assert.AreEqual(6, coordinate.Y);
        }

        [TestMethod]
        public void TesrtRead7E()
        {
            var input = "7E";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);

            Assert.IsTrue(isCreated);
            Assert.AreEqual(4, coordinate.X);
            Assert.AreEqual(6, coordinate.Y);
        }


        [TestMethod]
        public void TesrtReadAB2()
        {
            var input = "AB2";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);
            Assert.IsFalse(isCreated);

        }

        [TestMethod]
        public void TesrtReadh56bb()
        {
            var input = "h56bb";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);
            Assert.IsFalse(isCreated);

        }

        [TestMethod]
        public void TesrtRead123()
        {
            var input = "123";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);
            Assert.IsFalse(isCreated);

        }


        [TestMethod]
        public void TestInvalidInput()
        {
            var input = "asdfdfas";

            var (isCreated, coordinate) = Coordinate.TryCreateCoordinate(input, 16);

            Assert.IsFalse(isCreated);
        }
    }
}