namespace Matrix_Rotation_Algo.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void RotateTest1()
        {
            var input = new List<int?> { 1, 2, 3 };
            var expected = new List<int?> { 2, 3, 1 };
            var actual = input.Rotate();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RotateTest2()
        {
            var input = new List<int?> { 1, 2, 3 };
            var expected = new List<int?> { 3, 1, 2 };
            var actual = input.Rotate(2);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RotateTest3()
        {
            var input = new List<int?> { 1, 2, null };
            var expected = new List<int?> { 2, null, 1 };
            var actual = input.Rotate();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InsertRingTest1()
        {
            var input = new List<int?> { 1, 2, 3, 4, 5, 6,7,8,9,10,11,12};
            var expected = new List<List<int?>>
            {
                new List<int?>{ 1, 2, 3, 4 },
                new List<int?>{ 12, null, null, 5 },
                new List<int?>{ 11, null, null, 6 },
                new List<int?>{ 10, 9, 8, 7 }
            };
            var baseMatrix = new List<List<int?>>
            {
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null }
            };
            var actual = Result.insertRing(input, 0, baseMatrix);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void InsertRingTest2()
        {
            var input = new List<int?> { 1, 2, 3, 4};
            var expected = new List<List<int?>>
            {
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, 1, 2, null },
                new List<int?>{ null, 4, 3, null },
                new List<int?>{ null, null, null, null }
            };
            var baseMatrix = new List<List<int?>>
            {
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null }
            };
            var actual = Result.insertRing(input, 1, baseMatrix);
            Assert.Equal(expected, actual);
        }
    }
}