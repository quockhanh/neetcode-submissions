// 2. Sorting (Good)
// Intuition
// If we sort the numbers first, then all consecutive values will appear next to each other.
// This makes it easy to walk through the sorted list and count how long each consecutive sequence is. 
// We simply move forward while the current number matches the expected next value in the sequence. 
// Duplicates don’t affect the result—they are just skipped—while gaps reset the streak count. 
// This approach is simpler and more organized than the brute force method because sorting places all potential sequences in order.

public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }

        // Sort to let all consecutive values appear next the each other
        Array.Sort(nums);

        // Because array has at least 1 item
        int longest = 1; // final result
        int streak = 1;  // length of current sequence
        int previous = nums[0]; // last value in current sequence

        for (int i = 1; i < nums.Length; i++) {
            int current = nums[i];

            if (current == previous) {
                // Same value, just continue, not increase `streak`
                continue;
            }

            if (current == previous + 1) {
                // Still in that sequence, increase streak count and update longest value
                streak++;
                if (streak > longest) {
                    longest = streak;
                }
                // Or: longest = Math.Max(longest, streak);
            } 
            else 
            {
                // Current item is not the continue of previous one
                // That is new sequence. Let's reset the streak count
                streak = 1;
            }

            previous = current;
        }

        return longest;
    }
}
