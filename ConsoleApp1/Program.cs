using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start {DateTime.Now}");
            //var init = new int[] { 2,1,0,3,4,5,6,7 };
            var init = new int[] { 0, 23, 6, 11, 4, 9, 18, 17, 20, 19, 10, 9, 12, 13, 14, 15, 16, 21, 8, 5, 24, 7, 22, 25, 26, 3, 2 };
            var solver = (Solver)new SolverFirstResultLargeur(new C3x3ParamSolver(), init);
            var res = solver.Solve().Result;
            var formatter = new SolutionsConsoleFormater(res);
            var strHumain = formatter.Format();
            Console.WriteLine(strHumain);
            Console.WriteLine($"Hello World! {DateTime.Now}");
            Console.ReadLine();
        }
    }
}
