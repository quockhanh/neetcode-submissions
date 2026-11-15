// 2. Two Pointers
// Using two pointers lets us efficiently search for the maximum area without checking every pair.
// We start with the widest container (left at start, right at end).
// The height is limited by the shorter line, so to potentially increase the area, we must move the pointer at the shorter line inward. 
// Moving the taller line never helps because it keeps the height the same but reduces the width. 
// By always moving the shorter side, we explore all meaningful possibilities.
public class Solution {
    public int MaxArea(int[] heights) {
        int result = 0;

        int l = 0;
        int r = heights.Length - 1;
        while (l < r) 
        {
            int area = (r - l) * Math.Min(heights[l], heights[r]);
            
            // result = Math.Max(result, area);
            if (area > result) 
            { 
                result = area;
            }

            if (heights[l] <= heights[r]) 
            {
                l++;
            } 
            else 
            {
                r--;
            }
        }

        return result;
    }
}
