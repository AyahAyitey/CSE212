public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Create a new array of doubles whose size is 'length'. This array
        //    will hold the multiples and is what the function returns.
        // 2. Loop with an index i starting at 0 and stopping before 'length',
        //    so the loop runs exactly 'length' times.
        // 3. On each pass, calculate the multiple as number * (i + 1).
        //    The "+ 1" is needed because the first multiple is number * 1,
        //    not number * 0. Store the result at position i in the array.
        //    Example: MultiplesOf(7, 5) stores 7*1, 7*2, 7*3, 7*4, 7*5
        //    which is {7, 14, 21, 28, 35}.
        // 4. When the loop finishes, return the array.

        // Step 1: create the result array with room for 'length' values
        double[] multiples = new double[length];

        // Steps 2 and 3: fill each position with the next multiple
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 4: return the finished array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Rotating right by 'amount' means the last 'amount' items move to
        //    the front of the list, and the remaining items shift after them.
        //    Example: {1,2,3,4,5,6,7,8,9} with amount 3 -> {7,8,9,1,2,3,4,5,6}.
        // 2. Work out where the "tail" (the items that move) starts:
        //    splitIndex = data.Count - amount.
        //    Because amount is between 1 and data.Count inclusive, splitIndex
        //    is always between 0 and data.Count - 1, so it is a valid index.
        // 3. Use GetRange(splitIndex, amount) to copy the tail into a new list.
        // 4. Use RemoveRange(splitIndex, amount) to delete the tail from the
        //    original list, leaving only the items that were not rotated.
        // 5. Use InsertRange(0, tail) to put the tail at the front of the
        //    original list. The list is changed in place, so nothing is returned.
        // 6. Edge case: if amount equals data.Count, the whole list is the tail,
        //    so it is removed and re-inserted unchanged, which is correct
        //    because a full rotation gives back the same list.

        // Step 2: find where the tail begins
        int splitIndex = data.Count - amount;

        // Step 3: copy the last 'amount' items
        List<int> tail = data.GetRange(splitIndex, amount);

        // Step 4: remove those items from the end of the original list
        data.RemoveRange(splitIndex, amount);

        // Step 5: put them at the front
        data.InsertRange(0, tail);
    }
}
