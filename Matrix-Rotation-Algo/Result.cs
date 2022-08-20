using System.Text;

public static class RingExtensions
{
    public static List<int?> Rotate(this List<int?> that)
    {
        var carry = that[0];
        return new List<int?>(that.Skip(1).Take(that.Count() - 1).Append(carry).ToList());
    }

    public static List<int?> Rotate(this List<int?> that, int times)
    {
        var x = that;
        for (int count = 0; count < times; count++)
        {
            x = x.Rotate();
        }
        return x;
    }

    public static List<int?> ExtractRing(this List<List<int?>> that, int ringLevel)
    {
        var width = that.First().Count();
        var height = that.Count();
        var topBorder = that.Skip(ringLevel)
                            .First()
                            .Skip(ringLevel)
                            .Take(width - ringLevel * 2);
        var bottomBorder = that.Skip(height - ringLevel - 1)
                               .First()
                               .Skip(ringLevel)
                               .Take(width - ringLevel * 2)
                               .Reverse();
        var rightBorder = that.Skip(ringLevel + 1)
                              .Take(height - ringLevel * 2 - 2)
                              .Select(row => row.Last());
        var leftBorder = that.Skip(ringLevel + 1)
                              .Select(row => row.First())
                              .Take(height - ringLevel * 2 - 2)
                              .Reverse();

        return topBorder.Concat(rightBorder).Concat(bottomBorder).Concat(leftBorder).ToList();
    }

    public static List<List<int?>> InsertRingIntoMatrix(this List<int?> ring, List<List<int?>> matrix, int ringLevel)
    {
        var width = matrix.First().Count() - ringLevel * 2;
        var height = matrix.Count() - ringLevel * 2;

        var topBorder = ring.Take(width);
        var rightBorder = ring.Skip(topBorder.Count())
                              .Take(height - 2);
        var bottomBorder = ring.Skip(topBorder.Count() + rightBorder.Count())
                               .Take(width)
                               .Reverse();
        var leftBorder = ring.Skip(topBorder.Count() + rightBorder.Count() + bottomBorder.Count())
                             .Take(height - 2)
                             .Reverse();

        var matrixArray = new int?[matrix.Count][];

        for (int rowCount = 0; rowCount < matrix.Count; rowCount++)
        {
            matrixArray[rowCount] = matrix.Skip(rowCount).First().ToArray();
        }

        for (int rowCount = ringLevel; rowCount < (matrix.Count - ringLevel); rowCount++)
        {
            if (rowCount == ringLevel)
            {
                topBorder.ToArray().CopyTo(matrixArray[rowCount], ringLevel);
            }
            else if (rowCount == (matrix.Count - ringLevel - 1))
            {
                bottomBorder.ToArray().CopyTo(matrixArray[rowCount], ringLevel);
            }
            else
            {
                matrixArray[rowCount][0 + ringLevel] = (leftBorder.ToArray()[rowCount - 1]);
                matrixArray[rowCount][^(ringLevel + 1)] = rightBorder.ToArray()[rowCount - 1];
            }
        }

        var matrixReturn = new List<List<int?>>();
        foreach (var l in matrixArray)
        {
            matrixReturn.Add(l.ToList());
        }

        return matrixReturn;
    }
    public static List<int?> NormalizeRow(this List<int> that, int width)
    {
        var diff = width - that.Count;
        var l = that.Cast<int?>();
        for (int count = 0; count < diff; count++)
        {
            l = l.Append(null);
        }
        return l.ToList();
    }
    public static List<List<int?>> NormalizeMatrix(this List<List<int>> that, int width)
    {
        return that.Select(x => x.NormalizeRow(width)).ToList();
    }

    public static List<List<int?>> RotateCounterClockWise(this List<List<int?>> that, int rotationTimes)
    {
        var height = that.Count;
        var rings = height / 2 + height % 2;
        for (int count =0; count < rings; count++ )
        {
            that = that.ExtractRing(count).Rotate(rotationTimes).InsertRingIntoMatrix(that, count);
        }
        return that;
    }
}

public class Result
{



    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        var rings = 2 / 2;

        for (int ringCount = 0; ringCount < rings; ringCount++)
        {
            //var rotatedRing = rotateRing(extractRing(usedMatrix, ringCount), r);
            //insertRing(rotatedRing, ringCount, usedMatrix);
        }
        var sb = new StringBuilder();
        //usedMatrix.ForEach(x => sb.AppendLine(string.Join(' ', x.Select(y => y?.ToString() ?? " "))));
        Console.Write(sb.ToString());
    }

}
