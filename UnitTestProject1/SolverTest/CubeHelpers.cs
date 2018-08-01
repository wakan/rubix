using ConsoleApp1;
using ConsoleApp1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.SolverTest
{
    static class CubeHelpers
    {
        public static List<KeyValuePair<Move, int[]>> GetListNMoveAleatoire(
            Dictionary<Move, int[]> tts, int nbFois)
        {
            var moves = new List<KeyValuePair<Move, int[]>>(nbFois);
            for (int i = 0; i < nbFois; i++)
            {
                var m = getRandomMove(tts);
                moves.Add(m);
            }
            return moves;
        }

        public static int[] ApplyMovesToCube(int[] initcube, 
            IEnumerable<KeyValuePair<Move, int[]>> moves)
        {
            int[] cCube = initcube.ToArray();
            foreach (var m in moves)
            {
                cCube = ArrayHelpers.SwipeTab(cCube, m.Value);
            }
            return cCube;
        }

        static Random r = new Random();
        private static KeyValuePair<Move, int[]> getRandomMove(
            Dictionary<Move, int[]> tt)
        {
            int random = r.Next(tt.Count);
            return tt.ElementAt(random);
        }

        public static IEnumerable<KeyValuePair<Move, int[]>> GetMoveWithTransoFromMove(
            IEnumerable<Move> moves,
            Dictionary<Move, int[]> tt
            )
        {
            return moves.Select(m => new KeyValuePair<Move, int[]>(m, tt[m]));
        }

        public static IEnumerable<Move> Reverse(Dictionary<Move, Move> reversesData, IEnumerable<Move> moves)
        {
            return moves.Reverse().Select(m => reversesData[m]);
        }


    }
}
