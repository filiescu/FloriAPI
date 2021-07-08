using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        [Required]
        public string TipFloare { get; set; }
        public List<Stoc> Stocs { get; set; } = new List<Stoc>();
    }
}
