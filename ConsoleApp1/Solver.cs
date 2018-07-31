using ConsoleApp1.Helpers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solver
    {
        readonly ParamSolver _ParamSolver;
        readonly int[] _PositionInitials;
        public Solver(ParamSolver paramSolver, int[] positionInitials)
        {
            _ParamSolver = paramSolver;
            _PositionInitials = positionInitials;
        }
        int countNeedOptim = 0;
        public Task<List<List<Move>>> Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var mvts = new Stack<Move>(_ParamSolver.DeepthMaxSearch);
            var res = search(0, _PositionInitials, mvts);
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            return Task.FromResult(res);
        }

        string elementInHash;
        HashSet<string> listResultPasse = new HashSet<string>();

        List<List<Move>> search(int deepth, int[] tc, Stack<Move> mvts)
        {
            if (deepth >= _ParamSolver.DeepthMaxSearch)
            {
                return new List<List<Move>>();
            }
            if (Enumerable.SequenceEqual(tc, _ParamSolver.Tr))
            {
                return new List<List<Move>> { getResultFromListMvtsCurrent(mvts) };
            }
            elementInHash = string.Join(string.Empty, tc);
            if (listResultPasse.Contains(elementInHash))
            {
                ++countNeedOptim;
                return new List<List<Move>>();
            }

            var retour = new List<List<Move>>();

            foreach (var move in _ParamSolver.Tt)
            {
                if (_ParamSolver.MustSkipForOptim(move.Key, mvts))
                    continue;
                listResultPasse.Add(elementInHash);
                var ttc = move.Value;
                var trswipe = ArrayHelpers.SwipeTab(tc, ttc);
                mvts.Push(move.Key);
                var ret = search(deepth + 1, trswipe, mvts);
                retour.AddRange(ret);
                mvts.Pop();
            }
            return retour;
        }

        List<Move> getResultFromListMvtsCurrent(Stack<Move> mvts)
        {
            return mvts.Reverse().ToList();
        }

    }
}
