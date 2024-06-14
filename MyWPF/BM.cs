using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPF
{
    internal class BM
    {
            private double maxval = 100;
            private int[] buildLast(string pattern)
            {

                int[] last = new int[256];

                for (int i = 0; i < 256; i++)
                {
                    last[i] = -1; // initialize array
                }

                for (int i = 0; i < pattern.Length; i++)
                {
                    int idx = pattern[i];

                    last[idx] = i;
                }
                return last;
            }

            private void HammingDistance(string pattern, string text, int startIndex)
            {
                int distance = 0;
                int patternLength = pattern.Length;
                int textLength = text.Length;

                for (int i = 0; i < patternLength; i++)
                {
                    int textIndex = startIndex + i;
                    if (textIndex >= textLength)
                    {
                        return;
                    }

                    if (pattern[i] != text[textIndex])
                    {
                        distance++;
                    }
                }

                if (distance < maxval)
                {
                    maxval = distance;
                }

            }
            public double solveBM(string pattern, string text)
            {
                int m = pattern.Length;
                int n = text.Length;

                int[] last = buildLast(pattern);

                int i = m - 1;
                if (i > n - 1)
                {
                    throw new ArgumentException($"gak bisa");
                }

                int j = m - 1;

                do
                {
                    HammingDistance(pattern, text, i - (m - 1));

                    if (pattern[j] == text[i])
                    {
                        if (j == 0)
                        {
                            break;
                        }
                        else
                        { // looking-glass technique
                            i--;
                            j--;
                        }
                    }
                    else
                    { // character jump technique
                        int lo = last[text[i]]; // last occ
                        i = i + m - Math.Min(j, 1 + lo);
                        j = m - 1;
                    }
                } while (i <= n - 1);

                double kemiripan = 1 - (maxval / m);
                return kemiripan;
                // Console.WriteLine($"Tingkat kemiripan adalah: {kemiripan}");

            }
        

    }

}
