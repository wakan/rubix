using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static int[] SwipeTab(int[] te, int[] tt)
        {
            int[] tr = new int[8];
            for (int i = 0; i < te.Length; i++)
            {
                tr[i] = tt[te[i]];
            }
            return tr;
        }

        const int PROF_MAX_SEARCH = 23;

        static int[][] tt = new int[][] {
            //F
           new int[] { 2,0,3,1,4,5,6,7},
           //F'
           new int[] { 1,3,0,2,4,5,6,7},
           //F''
           new int[] { 3,2,1,0,4,5,6,7},
           //B
           new int[] { 0,1,2,3,5,7,4,6},
           //B'
           new int[] { 0,1,2,3,6,4,7,5},
             //B''
           new int[] { 0,1,2,3,7,6,5,4},
           //L
           new int[] { 4,1,0,3,6,5,2,7 },
           //L'
           new int[] { 2,1,6,3,0,5,4,7 },
           //L''
           new int[] { 6,1,4,3,2,5,0,7 },
           //R
           new int[] { 0,3,2,7,4,1,6,5 },
            //R'
           new int[] { 0,5,2,1,4,7,6,3 },
            //R''
           new int[] { 0,7,2,5,4,3,6,1 },
        };

        static int[] tr =  new int[] { 0,1,2,3,4,5,6,7 };

        static List<int[]> listResultPasse = new List<int[]>();

        static List<int[]> search(int deepth, int[] tc, Stack<int> mvts)
        {
            if (deepth > PROF_MAX_SEARCH)
            {
                return new List<int[]>();
            }
            if (Enumerable.SequenceEqual(tc, tr))
            {
                return new List<int[]> { mvts.ToArray() };
            }
            if (listResultPasse.Contains(tc, new EqualityComparer<int[]>((t1, t2) => Enumerable.SequenceEqual(t1, t2))))
            {
                bool isAOptim = true;
                return new List<int[]>();
            }

            int? precmvt = mvts.Any() ? mvts.Peek() : (int?)null;
            int? precprecmvt = mvts.Skip(1).Any() ? mvts.Skip(1).First() : (int?)null;

            var retour = new List<int[]>();

            for (int i = 0; i < tt.Length; i++)
            {
                if (mustSkipForOptim(i, precmvt, precprecmvt))
                    continue;
                listResultPasse.Add(tc);

                int[] ttc = tt[i];
                int[] trswipe = SwipeTab(tc, ttc);
                mvts.Push(i);
                var ret = search(deepth + 1, trswipe, mvts);
                retour.AddRange(ret);
                mvts.Pop();
            }
            return retour;
        }

        private static bool mustSkipForOptim(int i, int? precmvt, int? precprecmvt)
        {
            if (precmvt.HasValue)
            {
                //Si on a fait F avant alors ca ne sert a rien de faire F, F' ou F''
                //Si on a fait B avant alors ca ne sert a rien de faire B, B' ou B''
                //... pour R et L
                if (precmvt.Value / 3 == i / 3)
                    return true;
            }
            //if (precprecmvt.HasValue)
            //{
            //    int mvtgroup = i / 3;
            //    int precprecmvtgroup = precprecmvt.Value / 3;

            //    // si on a fait F puis B puis F c'est la meme chose que F'' et B
            //    //Idem pour L et R
            //     if (mvtgroup == 0 && precprecmvtgroup == 1
            //        || mvtgroup == 1 && precprecmvtgroup == 0
            //        || mvtgroup == 2 && precprecmvtgroup == 3
            //        || mvtgroup == 3 && precprecmvtgroup == 2
            //        )
            //        return true;
            //}
            return false;
        }

        static void Main(string[] args)
        {
            int[] init = new int[] { 0, 1, 2, 3, 5, 6, 4, 7 };
            var mvts = new Stack<int>(PROF_MAX_SEARCH);
            search(0, init, mvts);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }



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

    }
}
