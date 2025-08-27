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
