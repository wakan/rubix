using ConsoleApp1;
using ConsoleApp1.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1.Transformation.C3x3
{
    [TestClass]
    public class MvtUnitaire3x3Test
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C3x3ParamSolver();
        }
        protected void testswipeMove(Move m)
        {
            var tr = ArrayHelpers.SwipeTab(paramSolver.Tr, paramSolver.Tt[m]);
            Assert.IsTrue(Enumerable.SequenceEqual(paramSolver.Tt[m], tr));
        }
        [TestMethod]
        public void TransfoFTest()
        {
            var m = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoFPrimeTest()
        {
            var m = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoFSecondeTest()
        {
            var m = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoBTest()
        {
            var m = new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoBPrimeTest()
        {
            var m = new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoBSedondeTest()
        {
            var m = new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoLTest()
        {
            var m = new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoLPrimeTest()
        {
            var m = new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoLSecondeTest()
        {
            var m = new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoRTest()
        {
            var m = new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoRPrimeTest()
        {
            var m = new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoRSecondeTest()
        {
            var m = new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }

        [TestMethod]
        public void TransfoUTest()
        {
            var m = new Move { Identifiant = 'U', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoUPrimeTest()
        {
            var m = new Move { Identifiant = 'U', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoUSecondeTest()
        {
            var m = new Move { Identifiant = 'U', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoDTest()
        {
            var m = new Move { Identifiant = 'D', Sens = Move.EnumSens.Normal };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoDPrimeTest()
        {
            var m = new Move { Identifiant = 'D', Sens = Move.EnumSens.Prime };
            testswipeMove(m);
        }
        [TestMethod]
        public void TransfoDSecondeTest()
        {
            var m = new Move { Identifiant = 'D', Sens = Move.EnumSens.Seconde };
            testswipeMove(m);
        }


    }
}
