using System;
using System.Collections.Generic;

namespace ConsoleApp1.Helpers
{
    public static class ArrayHelpers
    {
        public class EqualityComparer<T> : IEqualityComparer<T>
        {
            public EqualityComparer(Func<T, T, bool> cmp)
            {
                this.cmp = cmp;
            }
            public bool Equals(T x, T y)
            {
                return cmp(x, y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }

            public Func<T, T, bool> cmp { get; set; }
        }

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
