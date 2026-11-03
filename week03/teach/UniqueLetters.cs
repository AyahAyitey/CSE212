// W03 Team Activity - Problem 1: Unique Letters (discussion problem)
// Goal: O(n) instead of O(n^2) by using a HashSet.

public static class UniqueLetters
{
    /// <summary>
    /// Approach 1: add letters one at a time; exit early on the first duplicate.
    /// Loop = O(n), Contains/Add = O(1)  =>  O(n) overall.
    /// </summary>
    public static bool AreUniqueLetters(string text)
    {
        var letters = new HashSet<char>();
        foreach (var letter in text)
        {
            if (letters.Contains(letter))
                return false;          // duplicate found
            letters.Add(letter);
        }
        return true;
    }

    /// <summary>
    /// Approach 2 (alternative): copy all letters into a set and compare sizes.
    /// If the set is smaller than the string, something was repeated. O(n).
    /// </summary>
    public static bool AreUniqueLettersAlt(string text)
    {
        var letters = new HashSet<char>(text);
        return letters.Count == text.Length;
    }
}
