
using ConsoleApp1.Hierarchie;
using System;
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
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,20, 23, 26, 19, 22, 25, 18, 21, 24 },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 24, 21, 18, 25, 22, 19, 26, 23, 20, },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 26, 25, 24, 23, 22, 21, 20, 19, 18 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal }] = new int[] { 18, 1, 2, 9, 4, 5, 0, 7, 8, 21, 10, 11, 12, 13, 14, 3, 16, 17, 24, 19, 20, 15, 22, 23, 6, 25, 26 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime }] = new int[] { 6, 1, 2, 15, 4, 5, 24, 7, 8, 3, 10, 11, 12, 13, 14, 21, 16, 17, 0, 19, 20, 9, 22, 23, 18, 25, 26 },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde }] = new int[] { 24, 1, 2, 21, 4, 5, 18, 7, 8, 15, 10, 11, 12, 13, 14, 9, 16, 17, 6, 19, 20, 3, 22, 23, 0, 25, 26 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 8, 3, 4, 17, 6, 7, 26, 9, 10, 5, 12, 13, 14, 15, 16, 23, 18, 19, 2, 21, 22, 11, 24, 25, 20 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 20, 3, 4, 11, 6, 7, 2, 9, 10, 23, 12, 13, 14, 15, 16, 5, 18, 19, 26, 21, 22, 17, 24, 25, 8 },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 26, 3, 4, 23, 6, 7, 20, 9, 10, 17, 12, 13, 14, 15, 16, 11, 18, 19, 8, 21, 22, 5, 24, 25, 2 },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Normal }] = new int[] { 2, 11, 20, 3, 4, 5, 6, 7, 8, 1, 10, 19, 12, 13, 14, 15, 16, 17, 0, 9, 18, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Prime }] = new int[] { 18, 9, 0, 3, 4, 5, 6, 7, 8, 19, 10, 1, 12, 13, 14, 15, 16, 17, 20, 11, 2, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Seconde }] = new int[] { 20, 19, 18, 3, 4, 5, 6, 7, 8, 11, 10, 9, 12, 13, 14, 15, 16, 17, 2, 1, 0, 21, 22, 23, 24, 25, 26 },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 2, 3, 4, 5, 24, 15, 6, 9, 10, 11, 12, 13, 14, 25, 16, 7, 18, 19, 20, 21, 22, 23, 26, 17, 8 },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 2, 3, 4, 5, 8, 17, 26, 9, 10, 11, 12, 13, 14, 7, 16, 17, 18, 19, 20, 21, 22, 23, 6, 15, 24 },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 2, 3, 4, 5, 26, 25, 24, 9, 10, 11, 12, 13, 14, 17, 16, 15, 18, 19, 20, 21, 22, 23, 8, 7, 6 } ,
        };

        public int[] Tr => new int[] { 0, 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26 };

        public Dictionary<Move, Move> Reverses => new Dictionary<Move, Move>
        {
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'F', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'F', Sens = Move.EnumSens.Seconde },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'B', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'B', Sens = Move.EnumSens.Seconde },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'L', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'L', Sens = Move.EnumSens.Seconde },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'R', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'R', Sens = Move.EnumSens.Seconde },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'D', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'D', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'U', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'D', Sens = Move.EnumSens.Seconde },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Normal }] = new Move { Identifiant = 'U', Sens = Move.EnumSens.Prime },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Prime }] = new Move { Identifiant = 'U', Sens = Move.EnumSens.Normal },
            [new Move { Identifiant = 'D', Sens = Move.EnumSens.Seconde }] = new Move { Identifiant = 'U', Sens = Move.EnumSens.Seconde },
        };


        public bool MustSkipForOptim(Move move, Node node)
        {
            Move? precmvt = node != null ? node.MoveCurrent : (Move?)null;
            Move? precprecmvt =
                 node != null
                ? node.Parent != null
                ? node.Parent.MoveCurrent
                : (Move?)null
                : null;
            Move? precprecprecmvt = node != null
                ? node.Parent != null
                ? node.Parent.Parent != null
                ? node.Parent.Parent.MoveCurrent
                : (Move?)null
                : null
                : null;
            if (precmvt.HasValue)
            {
                //Si on a fait F avant alors ca ne sert a rien de faire F, F' ou F''
                //Si on a fait B avant alors ca ne sert a rien de faire B, B' ou B''
                //... pour R et L
                if (precmvt.Value.Identifiant == move.Identifiant)
                    return true;

                if (precmvt.Value.Identifiant == 'B'
                    && move.Identifiant == 'F')
                    return true; //Ca sert a rien de faire le BF on aura deja fait le FB
                if (precmvt.Value.Identifiant == 'R'
                   && move.Identifiant == 'L')
                    return true;
            }
            if (precprecmvt.HasValue)
            {
                // si on a fait F puis B puis F c'est la meme chose que F'' et B donc on l'aura fait dans un autre mouvement ca ne sert a rien de la faire ici
                //Idem pour L et R
                if (precprecmvt.Value.Identifiant == move.Identifiant
                    && precmvt.Value.Identifiant == oppose(move.Identifiant))
                    return true;
            }
            if (precprecprecmvt.HasValue)
            {
                var moveIdentifiant = move.Identifiant;
                var opposeMoveIdentiant = oppose(moveIdentifiant);
                var precIdentifiant = precmvt.Value.Identifiant;
                var opposePrecIdentifiant = oppose(precIdentifiant);
                var precprecIdentifiant = precprecmvt.Value.Identifiant;
                var opposePrecprecIdentifiant = oppose(precprecIdentifiant);

                if (
                    (moveIdentifiant == 'F'
                    || moveIdentifiant == 'L'
                    || moveIdentifiant == 'U'
                    )
                    && move.Sens == Move.EnumSens.Seconde
                    && precmvt.Value.Sens == Move.EnumSens.Seconde
                    && precprecmvt.Value.Sens == Move.EnumSens.Seconde
                    && precprecmvt.Value.Identifiant == opposePrecIdentifiant
                    && precprecprecmvt.Value.Sens == Move.EnumSens.Seconde
                    && (precprecprecmvt.Value.Identifiant == opposeMoveIdentiant
                    || precprecprecmvt.Value.Identifiant == moveIdentifiant)
                    )
                    return true;

                if (
                    (moveIdentifiant == 'F'
                    || moveIdentifiant == 'L'
                    || moveIdentifiant == 'U'
                    )
                    && move.Sens == Move.EnumSens.Seconde
                    && precmvt.Value.Sens == Move.EnumSens.Seconde
                    && precmvt.Value.Identifiant == opposeMoveIdentiant
                    && precprecmvt.Value.Sens == Move.EnumSens.Seconde
                    && precprecprecmvt.Value.Sens == Move.EnumSens.Seconde
                    && precprecprecmvt.Value.Identifiant == opposePrecprecIdentifiant
                    )
                    return true;
            }
            return false;
        }

        private char oppose(char identifiant)
        {
            if (identifiant == 'F')
                return 'B';
            if (identifiant == 'B')
                return 'F';
            if (identifiant == 'L')
                return 'R';
            if (identifiant == 'R')
                return 'L';
            throw new ArgumentException("identifiant");
        }
    }
}
