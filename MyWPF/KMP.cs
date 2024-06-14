using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWPF
{
    internal class KMP
    {
        private double maxval = 100;

        private int[] BuildLPS(string pattern)
        {
            int m = pattern.Length;
            int[] lps = new int[m];
            int length = 0;
            int i = 1;

            lps[0] = 0; // lps[0] is always 0

            while (i < m)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
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

        public double solveKMP(string pattern, string text)
        {
            int m = pattern.Length;
            int n = text.Length;

            int[] lps = BuildLPS(pattern);

            int i = 0; // index for text
            int j = 0; // index for pattern

            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == m)
                {
                    HammingDistance(pattern, text, i - j);
                    j = lps[j - 1];
                }
                else if (i < n && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            double kemiripan = 1 - (maxval / m);
            return kemiripan;
        }
    }
}
