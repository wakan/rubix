﻿
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class C2x2ParamSolver : ParamSolver
    {
        public int DeepthMaxSearch => 25;

        public Dictionary<Move, int[]> Tt => new Dictionary<Move, int[]>
        {
            [new Move { Identifiant = "F", Sens = Move.EnumSens.Normal }] = new int[] { 2, 0, 3, 1, 4, 5, 6, 7 },
            [new Move { Identifiant = "F", Sens = Move.EnumSens.Prime }] = new int[] { 1, 3, 0, 2, 4, 5, 6, 7 },
            [new Move { Identifiant = "F", Sens = Move.EnumSens.Seconde }] = new int[] { 3, 2, 1, 0, 4, 5, 6, 7 },
            [new Move { Identifiant = "B", Sens = Move.EnumSens.Normal }] = new int[] { 0, 1, 2, 3, 5, 7, 4, 6 },
            [new Move { Identifiant = "B", Sens = Move.EnumSens.Prime }] = new int[] { 0, 1, 2, 3, 6, 4, 7, 5 },
            [new Move { Identifiant = "B", Sens = Move.EnumSens.Seconde }] = new int[] { 0, 1, 2, 3, 7, 6, 5, 4 },
            [new Move { Identifiant = "L", Sens = Move.EnumSens.Normal }] = new int[] { 4, 1, 0, 3, 6, 5, 2, 7 },
            [new Move { Identifiant = "L", Sens = Move.EnumSens.Prime }] = new int[] { 2, 1, 6, 3, 0, 5, 4, 7 },
            [new Move { Identifiant = "L", Sens = Move.EnumSens.Seconde }] = new int[] { 6, 1, 4, 3, 2, 5, 0, 7 },
            [new Move { Identifiant = "R", Sens = Move.EnumSens.Normal }] = new int[] { 0, 3, 2, 7, 4, 1, 6, 5 },
            [new Move { Identifiant = "R", Sens = Move.EnumSens.Prime }] = new int[] { 0, 5, 2, 1, 4, 7, 6, 3 },
            [new Move { Identifiant = "R", Sens = Move.EnumSens.Seconde }] = new int[] { 0, 7, 2, 5, 4, 3, 6, 1 },
        };

        public int[] Tr => new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

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
