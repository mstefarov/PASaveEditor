using System;
using System.Text.RegularExpressions;

namespace PASaveEditor.Model {
    struct Id {
        public readonly int I, U;

        public Id(int i, int u) {
            I = i;
            U = u;
        }


        static Regex IRegex = new Regex("^\\[i \\d+\\]$", RegexOptions.Compiled);
        public static bool IsI(string str) {
            return IRegex.IsMatch(str);
        }


        public static int ParseI(string str) {
            int idxOfSpace = str.IndexOf(' ');
            string numStr = str.Substring(idxOfSpace + 1, str.Length - idxOfSpace - 2);
            return Int32.Parse(numStr);
        }
    }
}
