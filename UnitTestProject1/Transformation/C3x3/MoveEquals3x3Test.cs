using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.SolverTest;

namespace UnitTestProject1.Transformation.C3x3
{
    [TestClass]
    public class MoveEquals3x3Test
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C3x3ParamSolver();
        }

        [TestMethod]
        public void IsEqualTest()
        {
            var listmoves1WithTransfo = CubeHelpers.GetMoveWithTransoFromMove(move1(), paramSolver.Tt);
            var listmoves2WithTransfo = CubeHelpers.GetMoveWithTransoFromMove(move2(), paramSolver.Tt);

            var cubeApresTransfoMove1 = CubeHelpers.ApplyMovesToCube(
                paramSolver.Tr, listmoves1WithTransfo);
            var cubeApresTransfoMove2 = CubeHelpers.ApplyMovesToCube(
                paramSolver.Tr, listmoves2WithTransfo);

            Assert.IsTrue(Enumerable.SequenceEqual(cubeApresTransfoMove1, cubeApresTransfoMove2));
        }

        IEnumerable<Move> move1()
        {
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
        }

        IEnumerable<Move> move2()
        {
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
        }

    }
}
