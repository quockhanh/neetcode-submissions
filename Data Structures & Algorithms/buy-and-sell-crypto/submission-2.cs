// 2. Two Pointers (Good)
// - l is the buy day (looking for the lowest price)
// - r is the sell day (looking for a higher price)
// If the price at r is higher than at l, we can make a profit — so we update the maximum.
// If the price at r is lower, then r becomes the new l because a cheaper buying price is always better.
public class Solution {
    public int MaxProfit(int[] prices) {
        int l = 0;     // Buy day
        int r = 1;     // Sell day
        int maxP = 0;  // Maximum profit

        while (r < prices.Length) {
            if (prices[r] > prices[l]) {
                int profit = prices[r] - prices[l];
                maxP = Math.Max(maxP, profit);
            } else {
                l = r;
            }

            r++;
        }

        return maxP;
    }
}
