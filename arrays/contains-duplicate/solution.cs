var sol = new Solution();
Console.WriteLine(sol.hasDuplicate([1, 2, 2, 3]));

public class Solution
{
    public bool hasDuplicate(int[] nums)
    {
        var hashset = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (hashset.Contains(nums[i])) return true;
            hashset.Add(nums[i]);
        }
        return false;
    }
}

/* Using a HashSet has O(n) time and space complexity.
HashSet is the primary data structure that is useful here.
For an even simpler solution, you could drop the whole array into a HashSet. This will automatically remove any duplicates, and then you could compare the length of the hash set with the length of the original array.

For better space complexity, but worse time complexity, you could sort the array, and then in each iteration compare the current value to the next value to see if it is a duplicate. */
