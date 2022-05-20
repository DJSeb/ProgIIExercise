using System;
using System.Collections.Generic;

namespace FewestNumberOfCoins
{
    internal class Program
    {
        static int FewestNumberOfCoins(int[] coins, int sum)
        {
            bool[] sawSums = new bool[sum];
            for (int i = 0; i < sum; i++)
                sawSums[i] = false;
            int numberOfCoins = coins.Length;
            Queue<(int,int)> queue = new Queue<(int, int)>(); //(current_sum, number_of_coins)
            queue.Enqueue((0, 0));

            while(queue.Count > 0)
            {
                (int, int) from_queue = queue.Dequeue();
                int currentSum = from_queue.Item1;
                int usedCoins = from_queue.Item2;

                for(int i = 0; i < numberOfCoins; i++)
                {
                    int newSum = currentSum + coins[i];

                    if(newSum == sum)
                    {
                        return usedCoins + 1;
                    }
                    else if(newSum < sum && !sawSums[newSum])
                    {
                        queue.Enqueue((newSum, usedCoins + 1));
                    }
                }
            }

            return 0;
        }

        static void Main(string[] args)
        {
            string[] coinsInput = Console.ReadLine().Split(' ');
            int[] coins = new int[coinsInput.Length];

            for (int i = 0; i < coinsInput.Length; i++)
            {
                coins[i] = int.Parse(coinsInput[i]);
            }

            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine(FewestNumberOfCoins(coins, sum));
        }
    }
}
