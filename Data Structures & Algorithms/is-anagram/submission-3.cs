public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();

        // 2 strings now have same length
        for (int i = 0; i < s.Length; i++) {
            countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
            countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
        }
       
        if (countS.Count != countT.Count) {
            return false;
        }

        // Compare character by character
        foreach (var kvp in countS) {
            char character = kvp.Key;
            
            // 1. Check if the character exists in countT first
            if (!countT.ContainsKey(character)) {
                return false;
            }
            
            // 2. Then compare the counts
            if (countT[character] != kvp.Value) {
                return false;
            }
        }

        return true;
    }
}
