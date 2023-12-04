using System.Text.RegularExpressions;

namespace Day1;

internal class Program
{
    static async Task Main(string[] args)
    {
        var pattern = @"\d|(one)|(two)|(three)|(four)|(five)|(six)|(seven)|(eight)|(nine)";
        var input = await File.ReadAllTextAsync("Input.txt");
        var lines = input.Split('\n');
        var numbers = new List<int>();
        foreach (var line in lines.AsReadOnly())
        {
            var first = Regex.Match(line, pattern).Value;
            var last = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
            var firstNumber = RetrieveNumber(first);
            var lastNumber = RetrieveNumber(last);
            numbers.Add(firstNumber * 10 + lastNumber);
        }
        Console.WriteLine("Total: {0}", numbers.Sum());
    }

    private static int RetrieveNumber(string match)
    {
        var digitDictionary = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };
        return match.Length > 1 ? digitDictionary[match] : match[0] - '0';
    }
}