// 2. Encoding & Decoding (Optimal)
public class Solution {
    public string Encode(IList<string> strs) {
        var sb = new StringBuilder();

        foreach (string str in strs) {
            sb.Append(str.Length);
            sb.Append('#');
            sb.Append(str);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s) {
        var result = new List<string>();

        int i = 0;

        while (i < s.Length) {
            int j = i;

            // Find the delimiter '#'
            while (s[j] != '#') {
                j++;
            }

            // Parse the length
            int length = int.Parse(s[i..j]);

            // Move past '#'
            i = j + 1;

            // Extract the original string
            result.Add(s.Substring(i, length));

            // Move to the next segment
            i += length;
        }

        return result;
    }
}
