using ConsoleApp1;
using ConsoleApp1.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace UnitTestProject1.SolverTest.C2x2
{
    [TestClass]
    public class SolveRandom2x2Test
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C2x2ParamSolver();
        }
        [TestMethod]
        public void SolveTest()
        {
            var moves = CubeHelpers.GetListNMoveAleatoire(paramSolver.Tt, 2);

            var cubeInit = CubeHelpers.ApplyMovesToCube(paramSolver.Tr, moves);
            var solver = (Solver)new SolverVertical(paramSolver, cubeInit);
            var sols = solver.Solve().Result;
            Console.WriteLine(string.Join(string.Empty, moves));
            var formatter = new SolutionsConsoleFormater(sols);
            var strHumain = formatter.Format();
            Console.WriteLine(strHumain);
            Console.WriteLine("Hello World!");
            Assert.IsTrue(sols.Contains(moves.Select(kv=>kv.Key).ToList(),
                new ArrayHelpers.EqualityComparer<List<Move>>((t1, t2) => t1.SequenceEqual(t2))));
        }
    }
}
