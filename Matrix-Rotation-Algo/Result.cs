using System.Text;

public static class RingExtensions
{
    public static List<int?> Rotate (this List<int?> that)
    {
        var carry = that[0];
        return new List<int?>(that.Skip(1).Take(that.Count() - 1).Append(carry).ToList());
    }

    public static List<int?> Rotate (this List<int?> that, int times)
    {
        var x = that;
        for (int count = 0; count < times; count++)
        {
            x = x.Rotate();
        }
        return x;
    }
}

public class Result
{
    public static List<int?> extractRing(List<List<int?>> matrix, int ringLevel)
    {
        var borderSize = matrix[0].Count;
        var usedMatrix = matrix.Skip(ringLevel).Take(borderSize - ringLevel);
        var topBorder = usedMatrix.First().Skip(1);
        var rightBorder = usedMatrix.Select(x => x.Last()).Skip(1);
        var bottomBorder = usedMatrix.Last().Skip(0).Reverse().Skip(1);
        var leftBorder = usedMatrix.Select(x => x.First()).Reverse().Skip(1);
        return topBorder.Concat(rightBorder).Concat(bottomBorder).Concat(leftBorder).ToList();
    }

    public static List<List<int?>> insertRing(List<int?> ring, int ringLevel, List<List<int?>> matrix)
    {
        var borderSize = ring.Count / 4;
        var topBorder = ring.Skip(0 * borderSize).Take(borderSize);
        var rightBorder = ring.Skip(1 * borderSize).Take(borderSize);
        var bottomBorder = ring.Skip(2 * borderSize).Take(borderSize);
        var leftBorder = ring.Skip(3 * borderSize).Take(borderSize);

        var matrixResult = new List<List<int?>>();

        matrixResult.Add(topBorder.Concat(rightBorder.Take(1)).ToList());

        var innerRightBorder = rightBorder.Skip(1);
        var innerLeftBorder = leftBorder.Skip(1).Reverse();

        for (int rowCount = 0; rowCount < borderSize - 1; rowCount++)
        {
            var usedRow = new int?[borderSize + 1];
            usedRow[0] = (innerLeftBorder.ToArray()[rowCount]);
            usedRow[^1] = innerRightBorder.ToArray()[rowCount];
            matrixResult.Add(usedRow.ToList());
        }

        matrixResult.Add(bottomBorder.Concat(leftBorder.Take(1)).Reverse().ToList());

        return matrixResult;
    }


    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        var width = matrix.Select(x => x.Count).Max();
        var rings = width / 2;
        List<List<int?>> usedMatrix = new List<List<int?>>();
        matrix.ForEach(x =>
        {
            var l = new List<int?>();
            l.AddRange(x.Select(y => (int?)y));
            while (l.Count < width)
            {
                l.Append(null);
            }
        });
        for (int ringCount = 0; ringCount < rings; ringCount++)
        {
            //var rotatedRing = rotateRing(extractRing(usedMatrix, ringCount), r);
            //insertRing(rotatedRing, ringCount, usedMatrix);
        }
        var sb = new StringBuilder();
        usedMatrix.ForEach(x => sb.AppendLine(string.Join(' ', x.Select(y => y?.ToString() ?? " "))));
        Console.Write(sb.ToString());
    }

}
