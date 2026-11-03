// Sample driver for the three W03 team activity problems.
Console.WriteLine("--- Unique Letters ---");
foreach (var s in new[] { "abcdefg", "abccdefg", "", "aA" })
    Console.WriteLine($"\"{s}\" -> {UniqueLetters.AreUniqueLetters(s)}");

Console.WriteLine("\n--- Display Sums ---");
DisplaySums.DisplaySumPairs(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

Console.WriteLine("\n--- Basketball ---");
Basketball.Run();
