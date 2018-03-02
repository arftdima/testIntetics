using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace test_Intetics
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate_file_of_prime_numbers(10000, 99999, "prNum.txt");
            var a = new List<long>();
            using (var sr = new StreamReader("prNum.txt", Encoding.Default))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                    a.Add(Int64.Parse(line));
            }

            Predicate<long> isPalindrome = (p) => p.ToString().Reverse().SequenceEqual(p.ToString());
            long ans = -1, v1 = -1, v2 = -1;
            for (int i = 0; i < a.Count; ++i)
            {
                for (int j = 0; j < a.Count; ++j)
                {
                    if (i == j) continue;
                    long p = a[i] * a[j];
                    if (isPalindrome(p) && p > ans)
                    {
                        ans = p;
                        v1 = a[i];
                        v2 = a[j];
                    }
                }
            }
            Console.WriteLine($"ans: {ans}\nv1: {v1}\nv2: {v2}");
        }

        static void generate_file_of_prime_numbers(int min, int max, String out_name_file)
        {
            var a = new bool[max];
            a[0] = true;
            for (int i = 2; Math.Pow(i, 2) <= max; ++i)
            {
                if (!a[i - 1])
                {
                    for (long j = (long)Math.Pow(i, 2); j <= max; j += i)
                    {
                        a[j - 1] = true;
                    }
                }
            }

            using (var sw = new StreamWriter(out_name_file, false, Encoding.Default))
            {
                for (int i = max - 1; i >= min - 1; --i)
                {
                    if (!a[i])
                    {
                        sw.WriteLine(i + 1);
                    }
                }
            }
        }
    }
}
