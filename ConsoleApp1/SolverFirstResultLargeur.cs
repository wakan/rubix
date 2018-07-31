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
            pl(new Node { CubeMove = PositionInitial, deepth = 0 } );
            sw.Stop();
            var time = sw.ElapsedMilliseconds;
            if (_Result.Any())
                return Task.FromResult(new List<List<Move>> { _Result });
            else
                return Task.FromResult(new List<List<Move>>());
        }
        List<Move> _Result = new List<Move>();

        string elementInHash;
        HashSet<string> listResultPasse = new HashSet<string>();
        void pl(Node node)
        {
            var fifo = new Queue<Node>();
            fifo.Enqueue(node);
            Node nodeDequeue;
            while (fifo.TryDequeue(out nodeDequeue))
            {
                traiter(nodeDequeue);
                foreach (var item in nodeDequeue.Fils)
                    fifo.Enqueue(item);
            }

        }
        void traiter(Node node)
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

            foreach (var move in Param.Tt)
            {
                if (Param.MustSkipForOptim(move.Key, node))
                    continue;
                var ttc = move.Value;
                var trswipe = ArrayHelpers.SwipeTab(node.CubeMove, ttc);
                node.Fils.Add(new Node
                {
                    CubeMove = trswipe,
                    deepth = node.deepth + 1,
                    MoveCurrent = move.Key,
                    Parent = node,
                });
            }
        }

        List<Move> getResultFromListMvtsCurrent(Node node)
        {
            List<Move> moves = new List<Move>(Param.DeepthMaxSearch);
            Node nodeCur = node;
            while (nodeCur.Parent != null)
            {
                moves.Add(nodeCur.MoveCurrent);
                nodeCur = nodeCur.Parent;
            }
            moves.Reverse();
            return moves;
        }

    }
}
