using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domino // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int nej = 0;
        static void tiskni(int[,] pole)
        {
            Console.WriteLine(pole.GetLength(0));
            for (int i = 0; i < pole.GetLength(0); i++)
            {
                for (int j = 0; j < pole.GetLength(1); j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string vstup = Console.ReadLine();
            int[] cisla = Array.ConvertAll(vstup.Split(" "), s => int.Parse(s));

            int n = cisla[0];
            int[,] kostky = new int[n, 2];
            int[,] matice = new int[39, 39];

            for(int i = 0; i < matice.GetLength(0); i++)
            {
                for(int j = 0; j < matice.GetLength(1); j++)
                {
                    matice[i, j] = 0;
                }
            }

            for (int k = 0; k < n; k++)
            {
                kostky[k, 0] = cisla[k * 2 + 1];
                kostky[k, 1] = cisla[k * 2 + 2];
            }

            for(int q = 0; q < n; q++)
            {
                matice[kostky[q, 0], kostky[q, 1]] += 1;
                matice[kostky[q, 1], kostky[q, 0]] += 1;
            }
            //tiskni(matice);
            //prohledavani(matice, 0, 38, 0);
            //Console.WriteLine(nej);
            //5 1 2 1 2 2 3 2 17 2 17
            prohledavani(matice, 0, 38, 0);
            Console.WriteLine(nej);
        }
        static int prohledavani(int[,] matic, int od, int kam, int maximum)
        {
            for (int j = od; j < kam; j++)
            {
                for (int k = 1; k < 39; k++)
                {

                    if (matic[j, k] != 0)
                    {
                        matic[j, k] -= 1;
                        matic[k, j] -= 1;
                        int p = prohledavani(matic, k, k + 1, maximum + 1);
                        if (p > nej)
                        {
                            nej = p;
                        }
                        matic[j, k] += 1;
                        matic[k, j] += 1;
                    }

                }
            }
            return maximum;
        }
    }
}