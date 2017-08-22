using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Auction.Models;
using System.Linq;

namespace Auction.Controllers
{
    public class SecondController : Controller
    {
        private AuctionContext _context;

        public SecondController(AuctionContext context)
        {
            _context = context;
        }


        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            return View("Dashboard");
        }


        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            // Other code
            ViewBag.name = PokeInfo["name"];
            ViewBag.height = PokeInfo["height"];
            ViewBag.weight = PokeInfo["weight"];

            return View("Pokemon");
        }
    }
}