namespace Implementations.PascalTriangle;

public static class Implementation
{
    public static IList<IList<int>> Generate(int numRows)
    {
        if (numRows <= 0)
        {
            throw new ArgumentException($"{nameof(numRows)} can't be less or equal then 0. Actual is {numRows}.");
        }

        var result = new int[numRows][];

        for (var i = 0; i < numRows; i++)
        {
            result[i] = CreateEmptyRow(i + 1);
        }

        for (var i = 1; i < numRows - 1; i++)
        {
            for (var j = 0; j < result[i].Length - 1; j++)
            {
                result[i + 1][j + 1] = result[i][j] + result[i][j + 1];
            }
        }

        return result
            .Select(e => (IList<int>) e.ToList())
            .ToList();
    }

    private static int[] CreateEmptyRow(int length)
    {
        var result = new int[length];
        result[0] = result[length - 1] = 1;
        return result;
    }
}