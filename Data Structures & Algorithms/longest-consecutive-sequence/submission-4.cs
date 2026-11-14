// 4. Hash Map (Use left right boundary) - Hard
// Intuition
// When we place a new number into the map, it may connect two existing sequences or extend one of them.
// Instead of scanning forward or backward, we only look at the lengths stored at the neighbors:

// mp[num - 1] gives the length of the sequence ending right before num
// mp[num + 1] gives the length of the sequence starting right after num

// By adding these together and including the current number, we know the total length of the new merged sequence.
// We then update the left boundary and right boundary of this sequence so the correct length can be retrieved later.
// This keeps the whole operation very efficient and avoids repeated work.

public class Solution {

public int LongestConsecutive(int[] nums)
{
    // Key = number value (or digit)
    // Value = The length of the consecutive sequence if that number is a boundary 
    // (or the current number being processed).
    Dictionary<int, int> mp = new Dictionary<int, int>();

    int res = 0;
    foreach (int num in nums)
    {
        // Skip duplicates
        if (mp.ContainsKey(num)) {
            continue;
        }

        // Get lengths of neighboring sequences
        int left = mp.GetValueOrDefault(num - 1, 0);
        int right = mp.GetValueOrDefault(num + 1, 0);

        // Calculate the merged sequence length
        int length = left + right + 1;

        // Store the length at the current number and boundaries
        mp[num] = length;
        mp[num - left] = length;
        mp[num + right] = length;

        res = Math.Max(res, length);
    }

    return res;
}

}
