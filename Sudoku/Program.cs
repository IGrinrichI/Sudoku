using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sudoku
{
    public struct Check
    {
        public List<int> variations;
    }
    class Reshator
    {
        public int[,] field;
        public Check[,] checks;
        public string dauj;
        public bool ended;
        public bool nulik;

        public Check[,] Modif(int x, int y, int del, Check[,] chuk)
        {
            Check[,] cheki = new Check[9, 9];
            CopyTo(chuk, cheki);
            int modX = x - x % 3;
            int modY = y - y % 3;
            for (int i = 0; i < 9; i++)
            {
                cheki[i, y].variations.Remove(del);
                cheki[x, i].variations.Remove(del);
                cheki[modX + i % 3, modY + i / 3].variations.Remove(del);
            }
            return cheki;
        }

        public int[] Minimum(int[,] fiold, Check[,] chuk)
        {
            Check[,] chak = chuk.Clone() as Check[,];
            int[] min = new int[2];
            Check minn;
            minn.variations = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 81; i++)
            {
                int modX = i / 9;
                int modY = i % 9;
                if (chak[modX, modY].variations.Count < minn.variations.Count && fiold[modX, modY] == 0)
                {
                    minn = chak[modX, modY];
                    min[0] = modX;
                    min[1] = modY;
                    if (minn.variations.Count == 0)
                    {
                        nulik = true;
                        break;
                    }
                }
            }
            if (minn.variations.Count == 9)
            {
                ended = true;
                DrawSudoku(fiold);
            }
            return min;
        }

        public void FFpls(int[,] floid, int[] iter, Check[,] chik)
        {
            int[,] jest = floid.Clone() as int[,];
            Check[,] chuk = new Check[9, 9];
            CopyTo(chik, chuk);
            int x = iter[0];
            int y = iter[1];
            foreach (int variant in chuk[x, y].variations)
            {
                if (ended) break;
                jest[x, y] = variant;
                Check[,] ccc = Modif(x, y, jest[x, y], chuk);
                int[] fff = Minimum(jest, ccc);
                if (!nulik) FFpls(jest, fff, ccc);
                nulik = false;
            }
        }

        private void DrawSudoku(int[,] field)
        {
            Console.WriteLine(field[0, 0] + " " + field[1, 0] + " " + field[2, 0] + "   " + field[3, 0] + " " + field[4, 0] + " " + field[5, 0] + "   " + field[6, 0] + " " + field[7, 0] + " " + field[8, 0] +
                "\n" + field[0, 1] + " " + field[1, 1] + " " + field[2, 1] + "   " + field[3, 1] + " " + field[4, 1] + " " + field[5, 1] + "   " + field[6, 1] + " " + field[7, 1] + " " + field[8, 1] +
                "\n" + field[0, 2] + " " + field[1, 2] + " " + field[2, 2] + "   " + field[3, 2] + " " + field[4, 2] + " " + field[5, 2] + "   " + field[6, 2] + " " + field[7, 2] + " " + field[8, 2] +
                "\n\n" + field[0, 3] + " " + field[1, 3] + " " + field[2, 3] + "   " + field[3, 3] + " " + field[4, 3] + " " + field[5, 3] + "   " + field[6, 3] + " " + field[7, 3] + " " + field[8, 3] +
                "\n" + field[0, 4] + " " + field[1, 4] + " " + field[2, 4] + "   " + field[3, 4] + " " + field[4, 4] + " " + field[5, 4] + "   " + field[6, 4] + " " + field[7, 4] + " " + field[8, 4] +
                "\n" + field[0, 5] + " " + field[1, 5] + " " + field[2, 5] + "   " + field[3, 5] + " " + field[4, 5] + " " + field[5, 5] + "   " + field[6, 5] + " " + field[7, 5] + " " + field[8, 5] +
                "\n\n" + field[0, 6] + " " + field[1, 6] + " " + field[2, 6] + "   " + field[3, 6] + " " + field[4, 6] + " " + field[5, 6] + "   " + field[6, 6] + " " + field[7, 6] + " " + field[8, 6] +
                "\n" + field[0, 7] + " " + field[1, 7] + " " + field[2, 7] + "   " + field[3, 7] + " " + field[4, 7] + " " + field[5, 7] + "   " + field[6, 7] + " " + field[7, 7] + " " + field[8, 7] +
                "\n" + field[0, 8] + " " + field[1, 8] + " " + field[2, 8] + "   " + field[3, 8] + " " + field[4, 8] + " " + field[5, 8] + "   " + field[6, 8] + " " + field[7, 8] + " " + field[8, 8]);
        }

        private void CopyTo(Check[,] a, Check[,] b)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    b[i, j].variations = new List<int>(a[i, j].variations);
                }
            }
        }

        public void SetField(string a, int[,] b)
        {
            for (int i = 0; i < 81; i++)
            {
                switch (a[i])
                {
                    case '.':
                        {
                            b[i % 9, i / 9] = 0;
                            break;
                        }
                    case '1':
                        {
                            b[i % 9, i / 9] = 1;
                            break;
                        }
                    case '2':
                        {
                            b[i % 9, i / 9] = 2;
                            break;
                        }
                    case '3':
                        {
                            b[i % 9, i / 9] = 3;
                            break;
                        }
                    case '4':
                        {
                            b[i % 9, i / 9] = 4;
                            break;
                        }
                    case '5':
                        {
                            b[i % 9, i / 9] = 5;
                            break;
                        }
                    case '6':
                        {
                            b[i % 9, i / 9] = 6;
                            break;
                        }
                    case '7':
                        {
                            b[i % 9, i / 9] = 7;
                            break;
                        }
                    case '8':
                        {
                            b[i % 9, i / 9] = 8;
                            break;
                        }
                    case '9':
                        {
                            b[i % 9, i / 9] = 9;
                            break;
                        }
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Stopwatch a = new Stopwatch();
            a.Start();
            Reshator s = new Reshator();
            s.ended = false;
            s.nulik = false;
            s.field = new int[9, 9] {
        { 0, 0, 3,  0, 2, 0,  6, 0, 0 },
        { 9, 0, 0,  3, 0, 5,  0, 0, 1 },
        { 0, 0, 1,  8, 0, 6,  4, 0, 0 },

        { 0, 0, 8,  1, 0, 2,  9, 0, 0 },
        { 7, 0, 0,  0, 0, 0,  0, 0, 8 },
        { 0, 0, 6,  7, 0, 8,  2, 0, 0 },

        { 0, 0, 2,  6, 0, 9,  5, 0, 0 },
        { 8, 0, 0,  2, 0, 3,  0, 0, 9 },
        { 0, 0, 5,  0, 1, 0,  3, 0, 0 }
        };
            s.checks = new Check[9, 9];
            s.dauj = "6.2.5.........3.4..........43...8....1....2........7..5..27...........81...6.....";
            s.SetField(s.dauj, s.field);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (s.field[i, j] == 0)
                    {
                        s.checks[i, j].variations = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    }
                    else
                    {
                        s.checks[i, j].variations = new List<int>();
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (s.field[i, j] != 0)
                    {
                        s.checks = s.Modif(i, j, s.field[i, j], s.checks);
                    }
                }
            }
            int[] bbb = s.Minimum(s.field, s.checks);
            Check[,] aaa = s.checks.Clone() as Check[,];
            int[,] ccc = s.field.Clone() as int[,];
            s.FFpls(s.field, s.Minimum(s.field, s.checks), s.checks);
            a.Stop();
            Console.WriteLine(a.ElapsedMilliseconds / 1000 + "." + a.ElapsedMilliseconds % 1000);
            Console.ReadKey();
        }
    }
}
