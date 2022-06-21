using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace curs11
{/// <summary>
/// Algoritmul lui Lee
/// </summary>
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            matrix = ReadMatrixFile();
            ViewMatrix(matrix);
            //Queue A = new Queue();
            //A.Push(new TriData(1, 2, 3));
            //A.Push(new TriData(4, 5, 6));
            //A.Push(new TriData(7, 8, 9));
            //A.Pop();
            //Console.WriteLine(A.view());
            Lee();
        }

        public static void Lee()
        {
            Queue A = new Queue();
            A.Push(new TriData(0, 0, 1));
            matrix[0, 0] = 1;
            while (!A.IsEmpty())
            {//BFS
                TriData t = A.Pop();
                if (t.l - 1 >= 0) //vecin nord
                {
                    if (matrix[t.l - 1, t.c] == 0)
                    {
                        A.Push(new TriData(t.l - 1, t.c, t.v + 1));
                        matrix[t.l - 1, t.c] = t.v + 1;
                    }
                }
                if (t.c + 1 < matrix.GetLength(1)) //vecin est
                {
                    if (matrix[t.l, t.c + 1] == 0)
                    {
                        A.Push(new TriData(t.l, t.c + 1, t.v + 1));
                        matrix[t.l, t.c + 1] = t.v + 1;
                    }
                }
                if (t.l + 1 < matrix.GetLength(0))//vecin sud
                {
                    if (matrix[t.l + 1, t.c] == 0)
                    {
                        A.Push(new TriData(t.l + 1, t.c, t.v + 1));
                        matrix[t.l + 1, t.c] = t.v + 1;
                    }
                }
                if (t.c - 1 >= 0) //vecin vest
                {
                    if (matrix[t.l, t.c - 1] == 0)
                    {
                        A.Push(new TriData(t.l, t.c - 1, t.v + 1));
                        matrix[t.l, t.c - 1] = t.v + 1;
                    }
                }
                Console.WriteLine();
                Console.WriteLine(A.view());
                ViewMatrix(matrix);
            }
        }

        private static int[,] ReadMatrixFile()
        {
            TextReader load = new StreamReader(@"..\..\TextFile1.txt");
            string[] t = load.ReadLine().Split(' ');
            int n = int.Parse(t[0]);
            int m = int.Parse(t[1]);
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] buffer = load.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = int.Parse(buffer[j]);
                }
            }
            return a;
        }

        private static void ViewMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
