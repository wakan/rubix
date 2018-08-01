using ConsoleApp1;
using ConsoleApp1.Hierarchie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1.C3x3
{
    [TestClass]
    public class MustSkipForOptim3x3Test
    {
        ParamSolver paramSolver;
        [TestInitialize]
        public void Init()
        {
            paramSolver = new C3x3ParamSolver();
        }
        [TestMethod]
        public void OpposeFFPrimeMoveTest()
        {
            var currentMove = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };
            var node = new Node { MoveCurrent = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal } };
            Assert.IsTrue(paramSolver.MustSkipForOptim(currentMove, node));
        }

        [TestMethod]
        public void OpposeNiv2FBFSecondeMoveTest()
        {
            var currentMove = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            var node = new Node { MoveCurrent = new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal, },
                Parent = new Node { MoveCurrent = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal } }
            };
            Assert.IsTrue(paramSolver.MustSkipForOptim(currentMove, node));
        }

        [TestMethod]
        public void OpposeNiv2FRFSecondeMoveTest()
        {
            var currentMove = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            var node = new Node
            {
                MoveCurrent = new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal, },
                Parent = new Node { MoveCurrent = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal } }
            };
            Assert.IsFalse(paramSolver.MustSkipForOptim(currentMove, node));
        }

        [TestMethod]
        public void SkipBFCarDejaFaitFBOuOnFeraFBTest()
        {
            var currentMove = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime };
            var node = new Node { MoveCurrent = new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal } };
            Assert.IsTrue(paramSolver.MustSkipForOptim(currentMove, node));
        }

        [TestMethod]
        public void FSecondeLSecondeRSecondeBSecondeFetBInverseTest()
        {
            var currentMove = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde };
            var node = new Node
            {
                MoveCurrent = new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde },
                Parent = new Node
                {
                    MoveCurrent = new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde },
                    Parent = new Node
                    {
                        MoveCurrent = new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde },
                    }
                }
            };
            Assert.IsTrue(paramSolver.MustSkipForOptim(currentMove, node));
        }

    }
}
