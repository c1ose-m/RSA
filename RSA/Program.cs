using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

namespace RSA
{
    internal class Program
    {
        static int isSimple (int number)
        {
            if (number == 1) return 0;
            for (int i = 2; i <= Sqrt(number); i++)
                if (number % i == 0)
                    return 0;
            return 1;
        }
        static int nSimple (int n)
        {
            int i = 0, nuber = 0;
            while (i < n)
            {
                nuber++;
                i += isSimple(nuber);
            }
            return nuber;
        }
        static int ostat(int x, int y, int z)
        {
            int ost = x;
            for (double i = y - 1; i > 0; i--)
                ost = (ost * x) % z;
            return ost;
        }
        static int closeKey(int p, int q, int e)
        {
            int fi = (p - 1) * (q - 1);
            int d = 0;
            int ost = 0;
            while (ost != 1)
            {
                d++;
                if (isSimple(d) == 1)
                    ost = (e * d) % fi;
            }
            return d;
        }
        static List<int> code(char[] c, int e, int n)
        {
            List<int> rez = new List<int>();
            for (int i = 0; i < c.Length; i++)
                rez.Add((char)ostat(c[i], e, n));
            return rez;
        }
        static List<char> decode(List<int> c, int d, int n)
        {
            List<char> rez = new List<char>();
            for (int i = 0; i < c.Count; i++)
                rez.Add((char)ostat(c[i], d, n));
            return rez;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int p = nSimple(random.Next(25, 50));
            int q = nSimple(random.Next(25, 50));
            int n = p * q;
            int e = 257;
            int d = closeKey(p, q, e);
            int symbol = 666;
            int shifr = ostat(symbol, e, n);
            char[] phraze = "лешаgей".ToCharArray();
            List<int> codePhraze = code(phraze, e, n);
            List<char> decoding = decode(codePhraze, d, n);
            Write($"исходный: ");
            foreach (char c in phraze)
                Write(c);
            WriteLine("\n\nзашифрованный: ");
            for (int i = 0; i < codePhraze.Count; i++)
                WriteLine($"{codePhraze[i]} ");
            Write($"\nрасшифрованный: ");
            foreach (char decode in decoding)
                Write(decode);
            ReadKey();
        }
    }
}
