/*
The MIT License(MIT)

Copyright(c) 2016 Ali Alatabbi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATABBI.Algorithms
{

    public static class Extensions
    {
        /// <summary>
        /// Extension method to compute the cover array of regular string  from its prefix table in linear time.  
        /// </summary>
        /// <param name="prefixArray"></param>
        /// <returns></returns>

        public static int[] PCR(this int[] prefixArray)
        {
            int n = prefixArray.Length;
            int[] c = new int[n];
            int[] maxalive = new int[n];
            int lastlim = 1;
            int i = 2;
            int j = 0;
            int lim = 0;
            int j1 = 0;
            int j2 = 0;

            while (lastlim < n - 1)
            {
                if (prefixArray[i] == 0)
                {
                    if (i > lastlim)
                        lastlim = i;
                }
                else
                {
                    j = prefixArray[i];
                    lim = i + j - 1;
                    if (lim > lastlim)
                    {
                        j1 = lastlim + 1 - i;
                        for (int i1 = lastlim + 1; i1 <= lim; i1++)
                        {
                            j1++;
                            if ((maxalive[j1] == 0 && i1 <= 2 * j1) || maxalive[j1] >= i1 - 1)
                            {
                                maxalive[j1] = i1;
                                c[i1] = j1;
                            }
                            else
                            {
                                maxalive[j1] = -1;
                            }
                        }
                        for (int i1 = lim; i1 >= lastlim; i1--)
                        {
                            j2 = c[j1];
                            while (j2 > 0 && maxalive[j2] > 0 && maxalive[j2] < i1)
                            {
                                maxalive[j2] = i1;
                                c[i1] = Math.Max(c[i1], j2);
                                j2 = c[j2];
                            }
                            j1--;
                        }
                        lastlim = lim;
                    }
                }
                i = i + 1;
            }
            return c;
        }


        /// <summary>
        /// Extension method to compute all rooted covers of indeterminate string from its prefix array.  
        /// </summary>
        /// <param name="prefixArray"></param>
        /// <returns></returns>
        public static int[] PCI(this int[] a)
        {
            int[] c = new int[a.Length + 1];
            try
            {
               c[0] = 0;
                int max = 0;
                for (int v = 0; v < a.Length; v++)
                {
                    c[v + 1] = a[v];
                    if (v > 0 && a[v] > max)
                        max = a[v];
                }
                int n = c.Length;
                int[] maxalive;
                maxalive = Enumerable.Repeat(0, n).ToArray();
                List<int> cList = new List<int>();
                for (int i = 2; i < n; i++)
                {
                    if (c[i] + i == n)
                    {
                        if (!cList.Contains(c[i]))
                            cList.Insert(0, c[i]);
                    }
                }
                for (int i = 2; i < n; i++)
                {
                    List<int> rList = new List<int>();
                    foreach (int q in cList)
                    {
                        if (q > c[i])
                            break;
                        int t = i + q - 1;
                        if ((maxalive[q] == 0 && t <= 2 * q) || maxalive[q] >= t - q)
                        {
                            maxalive[q] = t;
                        }
                        else
                        {
                            maxalive[q] = -1;
                            rList.Add(q);
                        }
                    }
                    foreach (int r in rList)
                        cList.Remove(r);
                }
                return c;
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                return c;
            }
        }



    }
}
