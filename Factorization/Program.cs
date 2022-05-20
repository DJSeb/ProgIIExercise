using System;
using System.Collections.Generic;

namespace Factorization
{
    internal class Program
    {
        static void Factorial(int number)
        {
            int carry;
            int temp;
            List<int> factorial = new List<int> { };

            factorial.Add(1);

            for (int i = 2; i <= number; i++)
            {
                carry = 0;
                for (int j = 0; j < factorial.Count; j++)
                {
                    temp = factorial[j] * i + carry;
                    factorial[j] = temp % 10;
                    carry = temp / 10;
                }
                while(carry != 0)
                {
                    factorial.Add(carry%10);
                    carry = carry / 10;
                }
            }

            int lenght = factorial.Count;

            for(int i = 0; i < lenght; i++)
            {
                Console.Write(factorial[lenght - i - 1]);
            }
        }

        static void Main(string[] args)
        {
            Factorial(99);
        }
    }
}
