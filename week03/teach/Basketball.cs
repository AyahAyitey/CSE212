// W03 Team Activity - Problem 3: Using a Map to Summarize Data
// Goal: total points per player across all years, then show the top 10.
// basketball.csv: column 0 = playerId, column 1 = year, column 8 = points.

public static class Basketball
{
    public static void Run()
    {
        // Key = playerId, Value = total points over all years
        var players = new Dictionary<string, int>();

        using var reader = new StreamReader("basketball.csv");
        reader.ReadLine(); // skip header row

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) continue;

            var fields = line.Split(',');
            var playerId = fields[0];

            if (!int.TryParse(fields[8], out var points))
                continue;      // skip rows with missing/invalid points

            if (players.ContainsKey(playerId))
                players[playerId] += points;
            else
                players[playerId] = points;
        }

        // Convert the map to an array and sort by total points, highest first
        var topPlayers = players.ToArray();
        Array.Sort(topPlayers, (p1, p2) => p2.Value.CompareTo(p1.Value));

        Console.WriteLine("Top 10 Players by Total Points");
        Console.WriteLine("Rank  Player ID     Points");
        for (var i = 0; i < 10 && i < topPlayers.Length; i++)
            Console.WriteLine($"{i + 1,-5} {topPlayers[i].Key,-13} {topPlayers[i].Value}");
    }
}
