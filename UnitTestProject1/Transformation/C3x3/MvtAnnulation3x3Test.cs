using ConsoleApp1;
using ConsoleApp1.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1.Transformation.C3x3
{
    [TestClass]
    public class MvtAnnulation3x3Test
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C3x3ParamSolver();
        }
        protected void testswipeMove(Move m1, Move m2)
        {
            var tri = ArrayHelpers.SwipeTab(paramSolver.Tr, paramSolver.Tt[m1]);
            var tr = ArrayHelpers.SwipeTab(tri, paramSolver.Tt[m2]);
            Assert.IsTrue(Enumerable.SequenceEqual(paramSolver.Tr, tr));
        }
        [TestMethod]
        public void TransfoFFPrimeTest()
        {
            var m1 = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal };
            var m2 = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };
            testswipeMove(m1, m2);
        }
        [TestMethod]
        public void TransfoFSecondeFSecondeTest()
        {
            var m = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            testswipeMove(m, m);
        }
        [TestMethod]
        public void TransfoBBPrimeTest()
        {
            var m1 = new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal };
            var m2 = new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime };
            testswipeMove(m1,m2);
        }
        [TestMethod]
        public void TransfoBSedondeBSecondeTest()
        {
            var m = new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde };
            testswipeMove(m, m);
        }
        [TestMethod]
        public void TransfoLLprimeTest()
        {
            var m1 = new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal };
            var m2 = new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime };
            testswipeMove(m1, m2);
        }
        [TestMethod]
        public void TransfoLSecondeTest()
        {
            var m = new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde };
            testswipeMove(m, m);
        }
        [TestMethod]
        public void TransfoRRPrimeTest()
        {
            var m1 = new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal };
            var m2 = new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime };
            testswipeMove(m1, m2);
        }
        [TestMethod]
        public void TransfoRSecondeTest()
        {
            var m = new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde };
            testswipeMove(m, m);
        }
    }
}
