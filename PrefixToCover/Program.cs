
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATABBI.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] p = new int[] { 3, 2, 1, 3,0,1 };
            var c =  p.PCR();
            Console.WriteLine(string.Format("c = {{{0}}}", string.Join(",",c)));
            Console.ReadLine();

        }
    }
}