using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public string TipFloare { get; set; }
        public List<Stoc> Stocs { get; set; } = new List<Stoc>();
    }
}
