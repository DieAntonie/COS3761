using System;
using System.Collections.Generic;

namespace COS3761.Domain
{
    abstract class Symbolic
    {
        private static Dictionary<char, bool> GlobalSymbolList = new Dictionary<char, bool>();
        public abstract char Symbol { get; set; }

        public Symbolic() { }
    }
}