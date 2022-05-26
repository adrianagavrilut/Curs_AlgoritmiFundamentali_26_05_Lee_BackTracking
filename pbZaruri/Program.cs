using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbZaruri
{//BackTracking
    /// <summary>
    /// Se dau 5 zaruri. 
    /// Se cere sa se afiseze toate combin care au suma 15.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] s = new int[n];
            bool[] b = new bool[n];
            //BK1(0, n, s);
            //BK2(0, n, s);
            BK3(0, n, s, b);
            Console.WriteLine("Done");
        }

        public static void BK1(int k, int n, int[] s)
        {//produs cartezian
            if (k >= n)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += s[i];
                }
                if (sum == 15)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(s[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    s[k] = i;
                    BK1(k + 1, n, s);
                }
            }
        }

        public static void BK2(int k, int n, int[] s)
        {//permutarile unei multimi (n^n)
            if (k >= n)
            {
                bool ok = true;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (s[i] == s[j])
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if(ok)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(s[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    s[k] = i + 1;
                    BK2(k + 1, n, s);
                }
            }
        }

        public static void BK3(int k, int n, int[] s, bool[] b)
        {//permutari (n!)
            if (k >= n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(s[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!b[i])
                    {
                        b[i] = true;
                        s[k] = i + 1;
                        BK3(k + 1, n, s, b);
                        b[i] = false;
                    }
                }
            }
        }
        //urmeaza aranjamente si combinari
    }
}
