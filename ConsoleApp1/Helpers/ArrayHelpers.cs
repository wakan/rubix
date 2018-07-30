using System;
using System.Collections.Generic;

namespace ConsoleApp1.Helpers
{
    public static class ArrayHelpers
    {
        public static int[] SwipeTab(int[] te, int[] tt)
        {
            int[] tr = new int[te.Length];
            for (int i = 0; i < te.Length; i++)
            {
                tr[i] = tt[te[i]];
            }
            return tr;
        }
    }
}
