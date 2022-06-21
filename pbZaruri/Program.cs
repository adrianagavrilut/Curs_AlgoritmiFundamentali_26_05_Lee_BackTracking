using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbZaruri
{   //BackTracking
    /// <summary>
    /// Se dau 4 zaruri. 
    /// Se cere sa se afiseze toate combin care au suma 15.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3; //4 multimi
            int[] s = new int[n]; //vector pt solutie
            bool[] b = new bool[n];
            //int k = 3;
            //int[] sol = new int[k];
            //BK1(0, n, s); //0 e nivelul de la care pornim
            BK2(0, n, s);
            //BK3(0, n, s, b);
            //BKAranj(0, n, k, sol);
            //BKCombin(0, n, k, sol);
            Console.WriteLine("Done");
        }
        /// <summary>
        /// Produs cartezian
        /// </summary>
        /// <param name="k"> nivelul la care ne aflam in solutie </param>
        /// <param name="n"> maximul, nr pozitii din solutie </param>
        /// <param name="s"> vectorul pt o solutei </param>
        public static void BK1(int k, int n, int[] s)
        {
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
                        Console.Write(s[i] + " ");//afiseaza solutia
                    }
                    Console.WriteLine();
                }
            }
            else //daca nivel < max
            {
                for (int i = 1; i <= 6; i++)//introduce valorile in solutie
                {
                    s[k] = i;
                    BK1(k + 1, n, s);
                }
            }
        }

        /// <summary>
        /// Permutarile unei multimi (n^n)
        /// in permutare nu se repeta valori
        /// </summary>
        public static void BK2(int k, int n, int[] s)
        {
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

        /// <summary>
        /// Permutarile unei multimi (n!)
        /// </summary>
        public static void BK3(int k, int n, int[] s, bool[] b)
        {
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

        public static void BKAranj(int niv, int n, int k, int[] sol)
        {   //aranj = toate permutarile submultimilor
            //in aranj nu se repeta elem si conteaza ordinea
            //solutia are k pozitii in care pot fi puse n elemente
            if (niv >= k)
            {
                //vf daca solutia este buna
                bool ok = true;
                for (int i = 0; i < k - 1; i++)
                {
                    for (int j = i + 1; j < k; j++)
                    {
                        if (sol[i] == sol[j])
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(sol[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sol[niv] = i;
                    BKAranj(niv + 1, n, k, sol);
                }
            }
        }

        public static void BKCombin(int niv, int n, int k, int[] sol)
        {   // comb = submultimi cu k elemente
            //in combinari nu se repeta si nu conteaza ordinea elem
            if (niv >= k)
            {
                //vf daca solutia este buna
                bool ok = true;
                for (int i = 0; i < k - 1; i++)
                {
                    for (int j = i + 1; j < k; j++)
                    {
                        if (sol[i] >= sol[j])//alegem solutia in care elem sunt ordonate cresc
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(sol[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sol[niv] = i;
                    BKCombin(niv + 1, n, k, sol);
                }
            }
        }
    }
}
