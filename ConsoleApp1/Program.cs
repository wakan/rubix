using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var init = new int[] { 2,1,0,3,4,5,6,7 };
            var solver = new Solver(new C2x2ParamSolver(), init);
            var res = solver.Solve().Result;
            var strHumain = string.Join(Environment.NewLine, res.Select(r=> string.Join(string.Empty, r)));
            Console.WriteLine(strHumain);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

       
    }
  
}
