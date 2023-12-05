using System.Text.RegularExpressions;

namespace Day4;

internal class Program
{
    static async Task Main(string[] args)
    {
        var input = await File.ReadAllTextAsync("Input.txt");
        var lines = input.Split('\n').Select(x => x.Split(':')[1].Split('|')).ToList();
        var totalWins = 0;
        foreach (var line in lines)
        {
            var winners = Regex.Matches(line[0], @"\d+").Select(x => x.Value).ToList();
            var yourNumbers = Regex.Matches(line[1], @"\d+").Select(x => x.Value).ToList();
            var matches = yourNumbers.Intersect(winners).Count();
            totalWins += (int)Math.Pow(2, matches - 1);
        }
        Console.WriteLine(totalWins);
    }
}