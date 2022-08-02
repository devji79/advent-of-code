using System;
using System.Collections.Generic;
using System.Text;

namespace Day_7
{
    public class BaggageRule
    {
        public string Colour { get; set; }
        public Dictionary<string, int> PermittedContent { get; set; }

        public BaggageRule()
        {
            PermittedContent = new Dictionary<string, int>();
        }
    }
}
