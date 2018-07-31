using ConsoleApp1;
using ConsoleApp1.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTableauTransfo
    {
        [TestMethod]
        public void TransfoF3x3Test()
        {
            var f = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal };
            testswipeMove(f);
        }

        private static void testswipeMove(Move m)
        {
            var param3x3 = new C3x3ParamSolver();
            var tr = ArrayHelpers.SwipeTab(param3x3.Tr, param3x3.Tt[m]);
            Assert.IsTrue(Enumerable.SequenceEqual(param3x3.Tt[m], tr));
        }

        [TestMethod]
        public void TransfoFFPrime3x3Test()
        {
            var param3x3 = new C3x3ParamSolver();
            int[] copieTravaille = param3x3.Tr.ToArray();

            var f = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal };
            var fprime = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };

            ArrayHelpers.SwipeTab(copieTravaille, param3x3.Tt[f]);
            ArrayHelpers.SwipeTab(copieTravaille, param3x3.Tt[fprime]);

        }
    }
}
