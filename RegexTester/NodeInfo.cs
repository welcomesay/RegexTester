namespace RegexTester
{
    using System;
    using System.Text.RegularExpressions;

    internal class NodeInfo
    {
        public readonly Capture Item;
        public readonly string Name;

        public NodeInfo(Capture item, string name)
        {
            this.Item = item;
            this.Name = name;
        }
    }
}

