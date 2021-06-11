using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI.Entities
{
    public class LotDTO
    {
        public int Id { get; set; }
        public string TipFloare { get; set; }

        public static LotDTO From(Lot lot) {
            if (lot == null) return null;
            LotDTO lotDTO = new LotDTO();
            lotDTO.Id = lot.Id;
            lotDTO.TipFloare = lot.TipFloare;
            return lotDTO;
        }

        public static List<LotDTO> From(List<Lot> lots)
        {
            List<LotDTO> lotDTOs = new List<LotDTO>();
            foreach (Lot lot in lots)
                lotDTOs.Add(From(lot));
            return lotDTOs;
        }
    }

}
