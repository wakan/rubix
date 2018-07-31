using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class SolutionsConsoleFormater
    {
        private List<List<Move>> _Solutions;
        public SolutionsConsoleFormater(List<List<Move>> solutions)
        {
            _Solutions = solutions;
        }
        public string Format()
        {
            var strHumain = string.Join(Environment.NewLine, 
                _Solutions.Select(r => string.Concat('[', r.Count, "] ", 
                string.Join(string.Empty, r))));
            return strHumain;
        }
    }
}
