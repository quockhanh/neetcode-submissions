// 2. Stack
// Whenever we see a closing bracket, 
// we simply check whether it matches the most recent opening bracket on top of the stack. 
// If it matches, we remove that opening bracket. 
// If it doesn't match (or the stack is empty), the string is invalid. 
// A valid string ends with an empty stack.
public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s) {
            if (c == '(' || c == '{' || c == '[') {
                // Store opening brackets.
                stack.Push(c);
            } else {
                // No opening bracket to match.
                if (stack.Count == 0) {
                    return false;
                }

                char top = stack.Peek();

                // Check whether the opening bracket matches.
                if ((c == ')' && top == '(') 
                    || (c == '}' && top == '{') 
                    || (c == ']' && top == '[')) {
                    stack.Pop();
                } else {
                    return false;
                }
            }
        }

        // All opening brackets must be closed.
        return stack.Count == 0;
    }
}
