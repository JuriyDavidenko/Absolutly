using System;
using System.Collections.Generic;
using System.Linq;

namespace Absolutly
{

    public static class Utility
    {
        private static Random rnd = new Random();

        public static int Rnd() => 
            rnd.Next(0, 2);

        public static int Rnd(int max) => 
            rnd.Next(0, max);

        public static int Rnd(int min, int max) => 
            rnd.Next(min, max);

        public static bool RndBool() => 
            Convert.ToBoolean(rnd.Next(0, 2));

        public static float RndFloat() => 
            (rnd.Next(0, 0x3e9) * 0.001f);

        public static string Str(params object[] args) => 
            string.Join(" ", (IEnumerable<string>) (from x in args select x.ToString()));

        public static string StrCol<T>(IEnumerable<T> col) => 
            string.Join(" ", (IEnumerable<string>) (from x in col select x.ToString()));

        public static string StrCol<T>(string separator, IEnumerable<T> col) => 
            string.Join(separator, (IEnumerable<string>) (from x in col select x.ToString()));

        public static string StrEx(string separator, params object[] args) => 
            string.Join(separator, (IEnumerable<string>) (from x in args select x.ToString()));
    }
}

