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

        // PLAN:
        // 1. Create a new double array with a size equal to length.
        // 2. Use a for loop to go through each position in the array.
        // 3. For each position, multiply the given number by the
        //    position number plus 1.
        // 4. Store the result in the corresponding position in the array.
        // 5. After the loop is finished, return the completed array.
        //
        // Example:
        // MultiplesOf(7, 5)
        // Position 0: 7 * 1 = 7
        // Position 1: 7 * 2 = 14
        // Position 2: 7 * 3 = 21
        // Position 3: 7 * 4 = 28
        // Position 4: 7 * 5 = 35

        // Create an array with the required length.
        double[] multiples = new double[length];

        // Loop through every position in the array.
        for (int i = 0; i < length; i++)
        {
            // Calculate and store the multiple.
            multiples[i] = number * (i + 1);
        }

        // Return the array containing the multiples.
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

        // PLAN:
        // 1. Find the position where the list should be divided.
        //    This is data.Count - amount.
        // 2. Use GetRange to copy the values from the split position
        //    to the end of the list. These values will move to the front.
        // 3. Use GetRange to copy the values from the beginning of
        //    the list to the split position. These values will move to the back.
        // 4. Clear the original list.
        // 5. Add the right portion to the original list first.
        // 6. Add the left portion to the original list after it.
        // 7. The original list is now rotated to the right.
        //
        // Example:
        // Original:  1, 2, 3, 4, 5, 6, 7, 8, 9
        // Amount: 3
        // Split: 9 - 3 = 6
        //
        // Right portion: 7, 8, 9
        // Left portion:  1, 2, 3, 4, 5, 6
        //
        // Result: 7, 8, 9, 1, 2, 3, 4, 5, 6

        // Find the index where the list should be split.
        int splitIndex = data.Count - amount;

        // Get the portion that will move to the front.
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Get the portion that will move to the back.
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Remove all the existing values from the original list.
        data.Clear();

        // Add the right portion first.
        data.AddRange(rightPart);

        // Add the left portion after it.
        data.AddRange(leftPart);
    }
}