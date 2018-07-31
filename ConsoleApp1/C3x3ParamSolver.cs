
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class C3x3ParamSolver : ParamSolver
    {
        public int DeepthMaxSearch => 25;

        public Dictionary<Move, int[]> Tt => new Dictionary<Move, int[]>
        {
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal }] = new int[] { 6, 3, 0, 7, 4, 1, 8,5, 2, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime }] = new int[] { 2, 5, 8, 1, 4, 7, 0, 3, 6, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde }] = new int[] { 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,20, 23, 26, 25, 22, 19, 18, 21, 24 },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 24, 21, 18, 25, 22, 19, 26, 23, 20, },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 26, 25, 24, 23, 22, 21, 20, 19, 18 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal }] = new int[] { 18, 1, 2, 9, 4, 5, 0, 7, 8, 21, 10, 11, 12, 13, 14, 3, 16, 17, 24, 19, 20, 15, 22, 23, 6, 25, 26 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime }] = new int[] { 6, 1, 2, 15, 4, 5, 24, 7, 8, 3, 10, 11, 12, 13, 14, 21, 16, 17, 0, 19, 20, 9, 22, 23, 18, 25, 26 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde }] = new int[] { 24, 1, 2, 21, 4, 5, 18, 7, 8, 15, 10, 11, 12, 13, 14, 9, 16, 17, 6, 19, 20, 3, 22, 23, 0, 25, 26 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 8, 3, 4, 17, 6, 7, 26, 9, 10, 5, 11, 12, 13, 14, 15, 16, 23, 18, 19, 2, 21, 22, 11, 24, 25, 20 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 20, 3, 4, 11, 6, 7, 2, 9, 10, 23, 11, 12, 13, 14, 15, 16, 5, 18, 19, 26, 21, 22, 17, 24, 25, 8 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 26, 3, 4, 23, 6, 7, 20, 9, 10, 17, 11, 12, 13, 14, 15, 16, 11, 18, 19, 8, 21, 22, 6, 24, 25, 3 },
        };

        public int[] Tr => new int[] { 0, 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26 };

        public bool MustSkipForOptim(Move move, Stack<Move> mvts)
        {
            Move? precmvt = mvts.Any() ? mvts.Peek() : (Move?)null;
            Move? precprecmvt = mvts.Skip(1).Any() ? mvts.Skip(1).First() : (Move?)null;
            if (precmvt.HasValue)
            {
                //Si on a fait F avant alors ca ne sert a rien de faire F, F' ou F''
                //Si on a fait B avant alors ca ne sert a rien de faire B, B' ou B''
                //... pour R et L
                if (precmvt.Value.Identifiant == move.Identifiant)
                    return true;
            }
            if (precprecmvt.HasValue)
            {
                // si on a fait F puis B puis F c'est la meme chose que F'' et B donc on l'aura fait dans un autre mouvement ca ne sert a rien de la faire ici
                //Idem pour L et R
                if (precprecmvt.Value.Identifiant == move.Identifiant)
                    return true;
            }
            return false;
        }
    }
}
