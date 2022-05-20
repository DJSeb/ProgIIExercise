using System;
using System.Collections.Generic;

namespace NumberOfArrays
{
    internal class Program
    {
        static int lenghtOfArray;
        static int maxValueInArray;
        static Dictionary<(int, int), int> memory = new Dictionary<(int, int), int> ();

        static int NumberOfPossibilitiesRec(int previous, int index)
        {
            
            if(memory.ContainsKey((previous,index)))
            {
                return memory[(previous,index)];
            }
            
            int possibilities = 0;

            if (index == 0)
            {
                for (int currentValue = 1; currentValue <= maxValueInArray; currentValue++)
                {
                    if (index == lenghtOfArray - 1)
                    {
                        possibilities++;
                    }
                    else
                    {
                        possibilities += NumberOfPossibilitiesRec(currentValue, index + 1);
                    }
                }
            }
            else
            {
                for (int currentValue = Math.Max(1, previous - 1); currentValue <= Math.Min(maxValueInArray, previous + 1); currentValue++)
                {
                    if (index == lenghtOfArray - 1)
                    {
                        possibilities++;
                    }
                    else
                    {
                        possibilities += NumberOfPossibilitiesRec(currentValue, index + 1);
                    }
                }
            }

            memory[(previous,index)] = possibilities;
            return possibilities;
        }

        static void Main(string[] args)
        {
            lenghtOfArray = int.Parse(Console.ReadLine());
            maxValueInArray = int.Parse(Console.ReadLine());

            Console.WriteLine(NumberOfPossibilitiesRec(0,0));
        }
    }
}
