using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Treinreizen.Domain.Entities;
using Treinreizen.Extensions;
using Treinreizen.Service;
using Treinreizen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinreizen.Controllers
{
    public class TreinController : Controller
    {
        //HotelsService hotelsService = new HotelsService();
        public IActionResult Wie()
        {
            return View();
        }

        public IActionResult Wat()
        {
            return View();
        }
        public IActionResult Waar()
        {
            return View();
        }
        //private RoutesService routesService;
        /*public TreinController()
        {
            routesService = new RoutesService();
        }

            */
        public IActionResult Steden()
        {
            StedenService stedenService = new StedenService();
            var list = stedenService.GetAll();
            return View(list);
        }
        
        public IActionResult ReisMogelijkheden()
        {
            ReisMogelijkhedenService reisMogelijkhedenService = new ReisMogelijkhedenService();
            var list = reisMogelijkhedenService.GetAll();
            return View(list);
        }
        
        [HttpGet]
        public IActionResult Home()
        {
            StedenService stedenService = new StedenService();
            KlasseService klasseService = new KlasseService();

            ZoekListVM zoekListVM = new ZoekListVM();

            zoekListVM.Steden = new SelectList(stedenService.GetAll(), "StadId", "Naam");

            zoekListVM.Klasses = new SelectList(klasseService.GetAll(), "KlasseId", "Klassenaam");

            return View(zoekListVM);
        }

        [HttpPost (Name ="Zoek Route")]
        public IActionResult Home(ZoekListVM zoekListVM)
        {
            ModelState.Clear();

            if (zoekListVM == null)
            {
                return NotFound();
            }

            /**if (zoekListVM.Van == zoekListVM.Naar)
            {
                return NotFound(); liever foutboodschap
            }*/

            StedenService stedenService = new StedenService();

            //routesService = new RoutesService();
            zoekListVM.Steden = new SelectList(stedenService.GetAll(), "StadId", "Naam");

            KlasseService klasseService = new KlasseService();
            zoekListVM.Klasses = new SelectList(klasseService.GetAll(), "KlasseId", "Klassenaam");
            zoekListVM.GeselecteerdeKlasse = klasseService.GetKlasseVanId(zoekListVM.Klasse);

            RittenService rittenService = new RittenService();
            TrajectService trajectService = new TrajectService();

            zoekListVM.RoutesHeen = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));
            zoekListVM.TrajectId = trajectService.GetTrajectId(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));
            zoekListVM.RoutesTerug = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

           

            if (ModelState.IsValid)
            {
                return View(zoekListVM);
            }
            else
            {
                zoekListVM.RoutesHeen = null;
                return View("Home", zoekListVM);
            }

        }


        //public IActionResult Passagiers(ZoekListVM zoekListVM, Decimal prijs)
        //{
        //    return View(zoekListVM);
        //}


        //TODO: DEZE CODE INORDE MAKEN
        [HttpPost]
        public IActionResult Boeken(ZoekListVM boeken, decimal prijs)
        {
            if (boeken == null)
            {
                return NotFound();
            }

            CartVM item = new CartVM
            {

                AantalTickets = boeken.Aantal,
                Class = boeken.GeselecteerdeKlasse.ToString(),
                TrajectId = boeken.TrajectId,
                Prijs = prijs
            };

            ShoppingCartVM shopping;

            if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
            {
                shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            }
            else
            {
                shopping = new ShoppingCartVM();
                shopping.Cart = new List<CartVM>();
            }

            shopping.Cart.Add(item);
            HttpContext.Session.SetObject("ShoppingCart", shopping);


            return RedirectToAction("Index", "ShoppingCart");
        }


        public IActionResult AlleRittenVanTraject()
        {
            RittenService rittenService = new RittenService();

            var list = rittenService.GetRittenVanTraject(Convert.ToInt16(2), Convert.ToInt16(7));

            return View(list);
        }
        
    }
}

      




