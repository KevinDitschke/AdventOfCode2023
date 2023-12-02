using System.Text.RegularExpressions;

namespace Day2;

internal class Program
{
    static async Task Main(string[] args)
    {
        var input = await File.ReadAllTextAsync("Input.txt");
        var lines = input.Split('\n');
        var idPattern = @"(\d+)";
        var numberPattern = @"\d+";
        var lowestMultiplied = 0;
        var ids = Enumerable.Range(1, lines.Length).ToList();
        var limitDictionary = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
        foreach (var line in lines)
        {
            var sets = line.Split(':')[1].Split(';');
            var lowestRed = 0;
            var lowestGreen = 0;
            var lowestBlue = 0;
            foreach (var set in sets)
            {
                var contents = set.Split(',');

                foreach (var content in contents)
                {
                    var count = Int32.Parse(Regex.Match(content, numberPattern).Value);
                    var color = Regex.Match(content, @"(red)|(green)|(blue)").Value;
                    switch (color)
                    {
                        case "red":
                            if (count > lowestRed)
                                lowestRed = count;
                            break;
                        case "green":
                            if (count > lowestGreen)
                                lowestGreen = count;
                            break;
                        case "blue":
                            if (count > lowestBlue)
                                lowestBlue = count;
                            break;
                    }

                    if (limitDictionary[color] < count)
                        ids.Remove(Int32.Parse(Regex.Match(line, idPattern).Value));
                }
            }
            lowestMultiplied += lowestRed * lowestGreen * lowestBlue;
        }
        Console.WriteLine(ids.Sum());
        Console.WriteLine(lowestMultiplied);
    }
}