using System.Text.RegularExpressions;

namespace Day3;

internal class Program
{
    static async Task Main(string[] args)
    {
        var input = await File.ReadAllTextAsync("Input.txt");
        var numberRegex = @"\d+";
        var numbers = Regex.Matches(input, numberRegex).Select(x => Int32.Parse(x.Value)).ToList();
        var array = input.Split('\n').Select(x => x.ToCharArray()).ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                if (!char.IsDigit(array[i][j]))
                    continue;
                
                
                Console.WriteLine($"{i}, {j}: {array[i][j]}");
            }
        }
    }
}