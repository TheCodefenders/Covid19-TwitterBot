using System;
using System.Collections;
using System.Collections.Generic;

namespace CovidTwitterBot.Models
{
    public class AllStatesResult
    {
        public int Count { get; set; }
        public IEnumerable<StateDataResult> Results { get; set; }
    }
}
