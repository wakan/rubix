﻿using ConsoleApp1;
using ConsoleApp1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.SolverTest
{
    static class CubeHelpers
    {
        public static int[] RandomizeCube(ParamSolver paramSolver, int nbFois, out List<Move> p_Moves)
        {
            p_Moves = new List<Move>(nbFois);
            var cubeCurrent = paramSolver.Tr.ToArray();
            for (int i = 0; i < nbFois; i++)
            {
                KeyValuePair<Move, int[]> m = getRandomMove(paramSolver.Tt);
                p_Moves.Add(m.Key);
                cubeCurrent = ArrayHelpers.SwipeTab(cubeCurrent, m.Value);
            }
            return cubeCurrent;
        }
        static Random r = new Random();
        private static KeyValuePair<Move, int[]> getRandomMove(Dictionary<Move, int[]> tt)
        {
            int random = r.Next(tt.Count);
            return tt.ElementAt(random);
        }

    }
}
