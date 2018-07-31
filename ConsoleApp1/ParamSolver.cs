﻿
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface ParamSolver
    {
        int DeepthMaxSearch { get; }
        Dictionary<Move, int[]> Tt { get; }
        int[] Tr { get; }

        bool MustSkipForOptim(Move key, Stack<Move> mvts);
    }
}
