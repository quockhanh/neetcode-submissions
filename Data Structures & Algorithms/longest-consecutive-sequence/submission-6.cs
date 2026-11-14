// 3. Hash Set (Better)
// Intuition
// To avoid repeatedly recounting the same sequences, we only want to start counting when we find
// the beginning of a consecutive sequence. A number is the start of a sequence if num - 1 is not in
// the set. This guarantees that each consecutive sequence is counted exactly once.

// Once we identify such a starting number, we simply keep checking if num + 1, num + 2, … exist in
// the set and extend the streak as far as possible. This makes the solution efficient and clean
// because each number contributes to the sequence only one time.

public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> numSet = new HashSet<int>(nums);

        int longest = 0;
        foreach (int num in numSet) {
            // Only start counting if num is the beginning of a consecutive sequence.
            // A number is the start of a sequence if num - 1 is not in the set
            if (numSet.Contains(num - 1)) {
                continue;
            }

            int length = 1;
            // Extend the sequence as long as the next number exists.
            while (numSet.Contains(num + length)) {
                length++;
            }

            longest = Math.Max(longest, length);
        }

        return longest;
    }
}
