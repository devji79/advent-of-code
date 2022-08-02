using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_6
{
    public class Group
    {
        public IList<char[]> Responses { get; set; }

        public Group()
        {
            Responses = new List<char[]>();
        }

        public int DistinctResponses
        {
            get
            {
                return Responses.SelectMany(r => r).Distinct().Count();
            }
        }

        public int CommonResponses
        {
            get
            {
                var commonResponseTotal = 0;

                foreach (var responseChar in Responses.SelectMany(r => r).Distinct())
                {
                    var totalResponsesContainingChar = Responses.Count(r => r.Contains(responseChar));
                    if (totalResponsesContainingChar == Responses.Count)
                    {
                        commonResponseTotal++;
                    }
                }

                return commonResponseTotal;
            }
        }
    }
}
