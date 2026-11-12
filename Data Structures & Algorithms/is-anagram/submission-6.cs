// 1. Sorting
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        // Sort then compare 2 sorted string
        
        char[] sSort = s.ToCharArray();
        Array.Sort(sSort);

        char[] tSort = t.ToCharArray();
        Array.Sort(tSort);

        return new String(sSort) == new String(tSort);        
        //return sSort.SequenceEqual(tSort);
    }
}
