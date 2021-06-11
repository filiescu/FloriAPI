using FloriAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI
{
    public class Stoc
    {
        public int Id { get; set; }
        public DateTime DataIntrare { get; set; }
        public DateTime DataIesire { get; set; }
        public double PretIntrare { get; set; }
        public double PretIesire { get; set; }        
        public Lot Lot { get; set; }
        public int LotId { get; set; }
    }
}
