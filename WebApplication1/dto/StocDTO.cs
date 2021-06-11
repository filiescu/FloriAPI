using FloriAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloriAPI
{
    public class StocDTO
    {
        public int Id { get; set; }
        public DateTime DataIntrare { get; set; }
        public DateTime DataIesire { get; set; }
        public double PretIntrare { get; set; }
        public double PretIesire { get; set; }
        public LotDTO Lot { get; set; }

        public static StocDTO From(Stoc stoc) {
            StocDTO stocDTO = new StocDTO();
            if (stoc == null) return null;
            stocDTO.Id = stoc.Id;
            stocDTO.DataIntrare = stoc.DataIntrare;
            stocDTO.DataIesire = stoc.DataIesire;
            stocDTO.PretIntrare = stoc.PretIntrare;
            stocDTO.PretIesire = stoc.PretIesire;
            stocDTO.Lot = LotDTO.From(stoc.Lot);
            return stocDTO;
        }

        public static List<StocDTO> From(List<Stoc> stocs) {
            List<StocDTO> stocDTOs = new List<StocDTO>();
            foreach(Stoc stoc in stocs) {
                stocDTOs.Add(From(stoc));
            }
            return stocDTOs;
        }
    }
}
