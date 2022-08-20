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
            var actual = input.InsertRingIntoMatrix(baseMatrix, 0);
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
            var actual = input.InsertRingIntoMatrix(baseMatrix, 1);
            Assert.Equal(expected, actual);
        }
                [Fact]
        public void InsertRingTest3()
        {
            var input = new List<int?> { 1, 2, 3, 4};
            var expected = new List<List<int?>>
            {
                new List<int?>{ 1, null, null, null },
                new List<int?>{ null, 1, 2, null },
                new List<int?>{ null, 4, 3, null },
                new List<int?>{ null, null, null, 1 }
            };
            var baseMatrix = new List<List<int?>>
            {
                new List<int?>{ 1, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, null },
                new List<int?>{ null, null, null, 1 }
            };
            var actual = input.InsertRingIntoMatrix(baseMatrix, 1);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ExtractRingTest1()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 1, 2, 3, 4 },
                new List<int?>{ 12, 1, 2, 5 },
                new List<int?>{ 11, 4, 3, 6 },
                new List<int?>{ 10, 9, 8, 7 }
            };
            var expected = new List<int?> { 1, 2, 3, 4, 5, 6,7,8,9,10,11,12};

            var actual = input.ExtractRing(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ExtractRingTest2()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 1, 2, 3, 4 },
                new List<int?>{ 12, 1, 2, 5 },
                new List<int?>{ 11, 4, 3, 6 },
                new List<int?>{ 10, 9, 8, 7 }
            };
            var expected = new List<int?> { 1, 2, 3, 4};
             
             var actual = input.ExtractRing(1);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ExtractRingTest3()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04, 05},
                new List<int?>{ 14, 00, 00, 00, 06},
                new List<int?>{ 13, 00, 00, 00, 07},
                new List<int?>{ 12, 11, 10, 09, 08}
            };
            var expected = new List<int?> { 1, 2, 3, 4,5 ,6,7,8,9,10,11,12,13,14};
             
             var actual = input.ExtractRing(0);
            Assert.Equal(expected, actual);
        }
                [Fact]
        public void ExtractRingTest4()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04 },
                new List<int?>{ 14, 00, 00, 05 },
                new List<int?>{ 13, 00, 00, 06 },
                new List<int?>{ 12, 00, 00, 07 },
                new List<int?>{ 11, 10, 09, 08 }
            };
                        var expected = new List<int?> { 1, 2, 3, 4,5 ,6,7,8,9,10,11,12,13,14};

             
             var actual = input.ExtractRing(0);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void RotateMatrix1()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04 },
                new List<int?>{ 12, 13, 14, 05 },
                new List<int?>{ 11, 16, 15, 06 },
                new List<int?>{ 10, 09, 08, 07 }
            };
            var expected = new List<List<int?>>
            {
                new List<int?>{ 02, 03, 04, 05 },
                new List<int?>{ 01, 14, 15, 06 },
                new List<int?>{ 12, 13, 16, 07 },
                new List<int?>{ 11, 10, 09, 08 }
            };
            var actual = input.RotateCounterClockWise(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RotateMatrix2()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04 },
                new List<int?>{ 10, 11, 13, 05 },
                new List<int?>{ 09, 08, 07, 06 },
            };
            var expected = new List<List<int?>>
            {
                new List<int?>{ 02, 03, 04, 05 },
                new List<int?>{ 01, 13, 11, 06 },
                new List<int?>{ 10, 09, 08, 07 },
            };
            var actual = input.RotateCounterClockWise(1);
            Assert.Equal(expected, actual);
        }
                [Fact]
        public void RotateMatrix3()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04, 05},
                new List<int?>{ 14, 15, 16, 17, 06},
                new List<int?>{ 13, 20, 19, 18, 07},
                new List<int?>{ 12, 11, 10, 09, 08}
            };
            var expected = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04, 05},
                new List<int?>{ 14, 15, 16, 17, 06},
                new List<int?>{ 13, 20, 19, 18, 07},
                new List<int?>{ 12, 11, 10, 09, 08}
            };
            var actual = input.RotateCounterClockWise(1);
            Assert.Equal(expected, actual);
        }
                [Fact]
        public void RotateMatrix4()
        {
            var input = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04 },
                new List<int?>{ 14, 15, 16, 05 },
                new List<int?>{ 13, 20, 17, 06 },
                new List<int?>{ 12, 19, 18, 07 },
                new List<int?>{ 11, 10, 09, 08 }
            };
            var expected = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, 04 },
                new List<int?>{ 14, 15, 16, 05 },
                new List<int?>{ 13, 20, 17, 06 },
                new List<int?>{ 12, 19, 18, 07 },
                new List<int?>{ 11, 10, 09, 08 }
            };
            var actual = input.RotateCounterClockWise(1);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NormalizeRow ()
        {
            var input = new List<int> { 1, 2 };
            var expected = new List<int?> { 1, 2, null, null };
            var actual = input.NormalizeRow(4);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NormalizeMatrix()
        {
            var input = new List<List<int>>
            {
                new List<int>{ 01, 02, 03 },
                new List<int>{ 12, },
                new List<int>{ 11, 16, 15, 06 },
                new List<int>{ 10, 09 }
            };
            var expected = new List<List<int?>>
            {
                new List<int?>{ 01, 02, 03, null },
                new List<int?>{ 12, null, null, null },
                new List<int?>{ 11, 16, 15, 06 },
                new List<int?>{ 10, 09, null, null }
            }; 
            var actual = input.NormalizeMatrix(4);
            Assert.Equal(expected, actual);
        }
    }
}