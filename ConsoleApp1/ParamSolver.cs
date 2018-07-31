
using ConsoleApp1.Hierarchie;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface ParamSolver
    {
        int DeepthMaxSearch { get; }
        Dictionary<Move, int[]> Tt { get; }
        Dictionary<Move, Move> Reverses { get; }
        int[] Tr { get; }

        bool MustSkipForOptim(Move key, Node node);
    }
}
