using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopSpots.Models
{
    public class Rootobject
    {
        public TopSpot[] Property1 {get; set;}
    }
    public class TopSpot
    {
        public string name { get; set; }
        public string description { get; set; }
        public float[] location { get; set; }
    }
}