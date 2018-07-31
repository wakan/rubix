using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using UnitTestProject1.SolverTest;

namespace UnitTestProject1.Transformation.C2x2
{
    [TestClass]
    public class MoveEqualsTest
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C2x2ParamSolver();
        }

        [TestMethod]
        public void IsEqualTest()
        {
            var listmoves1WithTransfo = getMoveWithTransoFromMove(move1());
            var listmoves2WithTransfo = getMoveWithTransoFromMove(move2());

            var cubeApresTransfoMove1 = CubeHelpers.ApplyMovesToCube(
                paramSolver.Tr, listmoves1WithTransfo);
            var cubeApresTransfoMove2 = CubeHelpers.ApplyMovesToCube(
                paramSolver.Tr, listmoves2WithTransfo);

            Assert.IsTrue(Enumerable.SequenceEqual(cubeApresTransfoMove1, cubeApresTransfoMove2));
        }

        private IEnumerable<KeyValuePair<Move, int[]>> getMoveWithTransoFromMove(
            IEnumerable<Move> moves)
        {
            return moves.Select(m => new KeyValuePair<Move, int[]>(m, paramSolver.Tt[m]));
        }

        IEnumerable<Move> move1()
        {
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal };
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };
        }

        IEnumerable<Move> move2()
        {
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            yield return new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
        }

    }
}
