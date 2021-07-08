using FloriAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FloriAPI.Controllers
{
    [Route("api/flori")]
    [ApiController]
    public class FloriController : ControllerBase
    {
        // -- GET ALL STOCS --
        [HttpGet("allStocs")]
        public ActionResult<List<StocDTO>> GetAllStoc()
        {
           var cc=  Program._context.Stocuri.ToList();
            var lot = cc[0].Lot;
            Console.WriteLine("++++++++++++++ " + lot);
            //return Ok(StocDTO.From(Program._context.Stocuri.OrderBy(e => e.Id).Include(l => l.Lot).ToList()));
            return Ok(StocDTO.From(Program._context.Stocuri.OrderBy(e => e.Id).ToList()));

        }

        // -- GET ALL LOTS --
        [HttpGet("allLots")]
        public List<LotDTO> GetAllLots()
        {
            List<Lot> lots = Program._context.Loturi.ToList();
            return LotDTO.From(lots);
        }

        // -- GET Stoc by id
        [HttpGet("{id}/stoc")]
        public StocDTO GetStoc(int id)
        {
            Program._context.Loturi.ToList();
            Stoc stoc = Program._context.Stocuri.Find(id);
            return StocDTO.From(stoc);
        }

        // -- GET Lot by id
        [HttpGet("{id}/lot")]
        public LotDTO GetLot(int id)
        {
            Lot lot = Program._context.Loturi.Find(id);
            return LotDTO.From(lot);
        }

        [HttpPost("addLot")]
        public void Post(LotDTO lotDTO)
        {
            Lot lot = new Lot();
            lot.TipFloare = lotDTO.TipFloare;
            Program._context.Loturi.Add(lot);
            Program._context.SaveChanges();
        }


        [HttpPost("addStoc")]
        public void Post(StocDTO stocDTO)
        {
            Stoc stoc = new Stoc();
            stoc.DataIesire = new DateTime();
            stoc.DataIntrare = new DateTime();
            stoc.PretIntrare = stocDTO.PretIntrare;
            stoc.PretIesire = stocDTO.PretIesire;

            stoc.Lot = getLotById(stocDTO);
            Program._context.Stocuri.Add(stoc);
            Program._context.SaveChanges();
        }

        private Lot getLotById(StocDTO stocDTO)
        {
            Lot lot;
            if (stocDTO.Lot.Id > 0)
            {
                lot = Program._context.Loturi.Find(stocDTO.Lot.Id);
            }
            else
            {
                lot = new Lot();
                lot.TipFloare = stocDTO.Lot.TipFloare;
                Program._context.Loturi.Add(lot);
            }
            return lot;
        }

        [HttpPut("updateLot")]
        public void Put(LotDTO lotDTO)
        {
            Lot lot = Program._context.Loturi.Find(lotDTO.Id);
            if (lot != null)
            {
                lot.TipFloare = lotDTO.TipFloare;
                Program._context.Loturi.Update(lot);
                Program._context.SaveChanges();
            }
        }

        [HttpPut("updateStoc")]
        public void Put(StocDTO stocDTO)
        {
            Stoc stoc = Program._context.Stocuri.Find(stocDTO.Id);
            if (stoc == null) return;

            stoc.DataIntrare = stocDTO.DataIntrare;
            stoc.DataIesire = stocDTO.DataIesire;
            stoc.PretIntrare = stocDTO.PretIntrare;
            stoc.PretIesire = stocDTO.PretIesire;
            stoc.Lot = Program._context.Loturi.Find(stocDTO.Lot.Id);
            if (stoc.Lot != null)
            {
                stoc.Lot.TipFloare = stocDTO.Lot.TipFloare;
                Program._context.Loturi.Update(stoc.Lot);
                Program._context.SaveChanges();
            }
            else // Daca lotul nu exista il creez
            {
                Lot lot = new Lot();
                lot.TipFloare = stocDTO.Lot.TipFloare;
                Program._context.Add(lot);

                stoc.Lot = lot;
                Program._context.Stocuri.Update(stoc);
                Program._context.SaveChanges();
            }

        }

        [HttpDelete("deleteLot")]
        public void DeleteLot(LotDTO lotDTO)
        {
            Lot lot = Program._context.Loturi.Find(lotDTO.Id);
            if (lot != null)
            {
                Program._context.Loturi.Remove(lot);
                Program._context.SaveChanges();
            }
        }

        [HttpDelete("deleteStoc")]
        public IActionResult DeleteStoc(StocDTO stocDTO)
        {
            Stoc stoc = Program._context.Stocuri.Find(stocDTO.Id);

            if (stoc == null)
            {
                return StatusCode(500, "Internal server error");
            }
            Program._context.Stocuri.Remove(stoc);
            Program._context.SaveChanges();
            return Ok(); 
        }

          [HttpDelete("deleteStocAndLot")]
         public void DeleteStocAndLot(StocDTO stocDTO)
         {
             Stoc stoc = Program._context.Stocuri.Find(stocDTO.Id);
             stoc.Lot = Program._context.Loturi.Find(stocDTO.Lot.Id);

             if (stoc == null) return;

           /*  if (stoc.LotId == stocDTO.Lot.Id)
             {
                 Program._context.Loturi.Remove(stoc.Lot);
             }
           */

             Program._context.Stocuri.Remove(stoc);
             Program._context.SaveChanges();
         }

    }
}
