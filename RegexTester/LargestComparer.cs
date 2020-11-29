namespace RegexTester
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class LargestComparer : IComparer<Match>
    {
        public int Compare(Match x, Match y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}

