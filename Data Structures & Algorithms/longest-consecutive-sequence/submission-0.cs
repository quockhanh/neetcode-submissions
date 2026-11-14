// 2. Sorting (Good)
// Intuition
// If we sort the numbers first, then all consecutive values will appear next to each other.
// This makes it easy to walk through the sorted list and count how long each consecutive sequence
// is. We simply move forward while the current number matches the expected next value in the
// sequence. Duplicates don’t affect the result—they are just skipped—while gaps reset the streak
// count. This approach is simpler and more organized than the brute force method because sorting
// places all potential sequences in order.

public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0)
            return 0;

        Array.Sort(nums);

        int res = 0;
        int curr = nums[0];
        int streak = 0;
        int i = 0;

        while (i < nums.Length) {
            if (nums[i] != curr) {
                curr = nums[i];
                streak = 0;
            }

            // Skip duplicates
            while (i < nums.Length && nums[i] == curr) {
                i++;
            }

            streak++;
            curr++;

            res = Math.Max(res, streak);
        }

        return res;
    }
}
