// 3. Dynamic Programming (Good)
// As we scan through the prices, we keep track of two things:
// 1. The lowest price so far → this is the best day to buy.
// 2. The best profit so far → selling today minus the lowest buy price seen earlier.
// At each price, we imagine selling on that day.
// The profit would be: current price - lowest price seen so far
// We then update:
// - the maximum profit,
// - and the lowest price if we find a cheaper one.
// This way, we make the optimal buy - sell decision in one simple pass.

public class Solution {
    public int MaxProfit(int[] prices) {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices) {
            // Update the lowest buying price
            minPrice = Math.Min(minPrice, price);

            // Calculate profit if we sell today
            int profit = price - minPrice;

            // Update maximum profit
            maxProfit = Math.Max(maxProfit, profit);
        }

        return maxProfit;
    }
}
