using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COS3761.Domain
{
    class Constant : Symbolic
    {
        public override char Symbol { get; set; }
        public string Description { get; private set; }

        public Constant()
        {

        }
    }
}
