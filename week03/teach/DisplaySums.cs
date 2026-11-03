// W03 Team Activity - Problem 2: Display Sums
// Goal: print every pair of numbers in a list that sums to 10, no duplicate pairs, O(n).
// Assumes the input list contains no duplicate numbers.

public static class DisplaySums
{
    public static void DisplaySumPairs(int[] numbers)
    {
        const int target = 10;
        var seen = new HashSet<int>();

        foreach (var x in numbers)
        {
            var complement = target - x;

            // Only check numbers already seen, so each pair is printed once (3+7, not 7+3).
            if (seen.Contains(complement))
                Console.WriteLine($"{x} + {complement} = {target}");

            seen.Add(x);
        }
    }
}

// Example (put in Program.cs):
//   DisplaySums.DisplaySumPairs(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
// Output: 6 + 4 = 10, 7 + 3 = 10, 8 + 2 = 10, 9 + 1 = 10
