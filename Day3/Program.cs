using System.Text;
using System.Text.RegularExpressions;

namespace Day3;

internal class Program
{
    private const string specialCharPattern = @"[^0-9.\r\n]";

    static async Task Main(string[] args)
    {
        var input = await File.ReadAllTextAsync("Input.txt");
        var array = input.Split('\n').Select(x => x.ToCharArray()).ToArray();
        var total = 0;
        for (var i = 0; i < array.Length; i++)
        {
            var numberBuilder = new StringBuilder();
            var isAdjacent = false;
            for (var j = 0; j < array[i].Length; j++)
            {
                if (!char.IsDigit(array[i][j]))
                {
                    if (numberBuilder.Length != 0 && isAdjacent)
                        total += int.Parse(numberBuilder.ToString());
                    numberBuilder = new StringBuilder();
                    isAdjacent = false;
                    continue;
                }

                numberBuilder.Append(array[i][j]);
                if (numberBuilder.ToString() == "409")
                    Console.WriteLine("409!!!!!");
                if (IsAdjacent(array, i, j + 1)
                    || IsAdjacent(array, i - 1, j + 1)
                    || IsAdjacent(array, i, j - 1)
                    || IsAdjacent(array, i + 1, j + 1)
                    || IsAdjacent(array, i + 1, j)
                    || IsAdjacent(array, i - 1, j + 1)
                    || IsAdjacent(array, i + 1, j - 1)
                    || IsAdjacent(array, i - 1, j - 1))
                    isAdjacent = true;

                Console.WriteLine($"{i}, {j}: {array[i][j]}");
            }
        }

        Console.WriteLine(total);
    }

    private static bool IsAdjacent(char[][] array, int row, int column)
    {
        try
        {
            if (Regex.Match(array[row][column].ToString(), specialCharPattern).Success)
            {
                Console.WriteLine($"Matching symbol:{array[row][column]}");
                return true;
            }
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }

        return false;
    }
}