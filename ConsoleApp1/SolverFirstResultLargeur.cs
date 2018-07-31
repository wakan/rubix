using ConsoleApp1.Helpers;
using ConsoleApp1.Hierarchie;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SolverFirstResultLargeur : Solver
    {
        public ParamSolver Param { get ; set ; }
        public int[] PositionInitial { get; set; }

        public SolverFirstResultLargeur(ParamSolver paramSolver, int[] positionInitials)
        {
            Param = paramSolver;
            PositionInitial = positionInitials;
        }
        int countNeedOptim = 0;
        public Task<List<List<Move>>> Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var mvts = new Stack<Move>(Param.DeepthMaxSearch);
            search(new Node { CubeMove = PositionInitial, deepth = 0 } );
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            return Task.FromResult(new List<List<Move>> { _Result });
        }
        List<Move> _Result = new List<Move>();

        string elementInHash;
        HashSet<string> listResultPasse = new HashSet<string>();
        void search(Node node)
        {
            if (node.deepth >= Param.DeepthMaxSearch
                || _Result.Any())
                return;
            if (Enumerable.SequenceEqual(node.CubeMove, Param.Tr))
            {
                _Result = getResultFromListMvtsCurrent(node);
                return;
            }
            elementInHash = string.Join(string.Empty, node.CubeMove);
            if (listResultPasse.Contains(elementInHash))
            {
                ++countNeedOptim;
                return;
            }
            listResultPasse.Add(elementInHash);

            var fifo = new Queue<Node>();

            foreach (var move in Param.Tt)
            {
                if (Param.MustSkipForOptim(move.Key, node))
                    continue;
                var ttc = move.Value;
                var trswipe = ArrayHelpers.SwipeTab(node.CubeMove, ttc);
               node.Fils.Add(new Node {
                    CubeMove = trswipe,
                    deepth = node.deepth + 1,
                    MoveCurrent = move.Key,
                    Parent = node,
                });
            }
            Node nodeDequeue;
            while (fifo.TryDequeue(out nodeDequeue))
                foreach (var item in nodeDequeue.Fils)
                    fifo.Enqueue(item);


        }

        List<Move> getResultFromListMvtsCurrent(Node node)
        {
            List<Move> moves = new List<Move>();
            while (node.Parent != null)
            {
                moves.Add(node.MoveCurrent);
            }
            moves.Reverse();
            return moves;
        }

    }
}
