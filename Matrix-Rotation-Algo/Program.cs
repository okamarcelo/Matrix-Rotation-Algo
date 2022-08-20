string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

int m = Convert.ToInt32(firstMultipleInput[0]);
int n = Convert.ToInt32(firstMultipleInput[1]);

int r = Convert.ToInt32(firstMultipleInput[2]);

List<List<int>> matrix = new List<List<int>>();

for (int i = 0; i < m; i++)
{
    matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
}

Result.matrixRotation(matrix, r);
