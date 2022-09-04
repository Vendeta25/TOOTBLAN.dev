using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TOOTBLAN.Models.Entities
{
    public class HitterProjection
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int TeamID { get; set; }
        public int AB { get; set; }
        public int PA { get; set; }
        public int R { get; set; }
        public int H { get; set; }
        public int D { get; set; }
        public int T { get; set; }
        public int HR { get; set; }
        public int RBI { get; set; }
        public int BB { get; set; }
        public int SO { get; set; }
        public int SB { get; set; }
        public int CS { get; set; }
        public decimal BA { get; set; }
        public decimal OBP { get; set; }
        public decimal SLG { get; set; }
        public decimal OPS { get; set; }
        public decimal ISO { get; set; }
        public decimal BABIP { get; set; }
        public decimal WAR  { get; set; }
        
    }
}
