using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var init = new int[] { 2,1,0,3,4,5,6,7 };
            var init = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 26, 21, 22, 23, 19, 25, 24 };
            var solver = new Solver(new C3x3ParamSolver(), init);
            var res = solver.Solve().Result;
            var strHumain = string.Join(Environment.NewLine, res.Select(r=> string.Join(string.Empty, r)));
            Console.WriteLine(strHumain);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
