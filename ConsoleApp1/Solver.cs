using ConsoleApp1.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Solver
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
            var mvts = new Stack<Move>(_ParamSolver.DeepthMaxSearch);
            return Task.FromResult(search(0, _PositionInitials, mvts));
        }

        List<int[]> listResultPasse = new List<int[]>();

        List<List<Move>> search(int deepth, int[] tc, Stack<Move> mvts)
        {
            if (deepth > _ParamSolver.DeepthMaxSearch)
            {
                return new List<List<Move>>();
            }
            if (Enumerable.SequenceEqual(tc, _ParamSolver.Tr))
            {
                return new List<List<Move>> { getResultFromListMvtsCurrent(mvts) };
            }
            if (listResultPasse.Contains(tc, new ArrayHelpers.EqualityComparer<int[]>((t1, t2) => Enumerable.SequenceEqual(t1, t2))))
            {
                ++countNeedOptim;
                var needOptim = true;
                return new List<List<Move>>();
            }

            var retour = new List<List<Move>>();

            foreach (var move in _ParamSolver.Tt)
            {
                if (_ParamSolver.MustSkipForOptim(move.Key, mvts))
                    continue;
                listResultPasse.Add(tc);

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
