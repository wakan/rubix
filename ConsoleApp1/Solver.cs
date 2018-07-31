using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface Solver
    {
        ParamSolver Param { get; set; }
        int[] PositionInitial { get; set; }
        Task<List<List<Move>>> Solve();
    }
}
