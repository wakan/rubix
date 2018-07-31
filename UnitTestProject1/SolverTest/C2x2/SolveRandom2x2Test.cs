using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var cubeInit = CubeHelpers.RandomizeCube(paramSolver, 2);
            var solver = new Solver(paramSolver, cubeInit);
            var sols = solver.Solve().Result;
            var formatter = new SolutionsConsoleFormater(sols);
            var strHumain = formatter.Format();
            Console.WriteLine(strHumain);
            Console.WriteLine("Hello World!");
            Assert.IsTrue(sols.Any());
        }
    }
}
