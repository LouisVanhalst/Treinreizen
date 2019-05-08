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

            zoekListVM.RoutesHeen = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));

            zoekListVM.RoutesTerug = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

            /*
             * 1 Brussel
             * 2 Londen
             * 3 Parijs
             * 4 Amsterdam
             * 5 Berlijn
             * 6 Rome
             * 7 Moskou
            */



            /*if (zoekListVM.Van == 2 && zoekListVM.Naar == 7) //Londen - Moskou      stop: Brussel + Berlijn
            {
                zoekListVM.RoutesHeen = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Van), 1, 5, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate);
                zoekListVM.RoutesTerug = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Naar), 5, 1, Convert.ToInt16(zoekListVM.Van), zoekListVM.TerugDate);
            }
            else if (zoekListVM.Van == 7 && zoekListVM.Naar == 2) //Moskou - Londen stop: Berlijn + Brussel
            {
                zoekListVM.RoutesHeen = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Van), 5, 1, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate);
                zoekListVM.RoutesTerug = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Naar), 1, 5, Convert.ToInt16(zoekListVM.Van), zoekListVM.HeenDate);

            }
            else if (zoekListVM.Van == 2 || zoekListVM.Naar == 2 && zoekListVM.Van != 1 && zoekListVM.Naar != 1 || (zoekListVM.Van == 4 && zoekListVM.Naar == 3)
                || (zoekListVM.Van == 3 && zoekListVM.Naar == 4) || (zoekListVM.Van == 4 && zoekListVM.Naar == 6)
                || (zoekListVM.Van == 6 && zoekListVM.Naar == 4)) //TODO Londen-brussel niet x2 
            //Londen - ?  || ? - Londen || Amsterdam - Parijs || Parijs - Amsterdam || Amsterdam - Rome || Rome - Amsterdam     stop: Brussel
            {
                zoekListVM.RoutesHeen = routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Van), 1, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate);
                zoekListVM.RoutesTerug= routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Naar), 1, Convert.ToInt16(zoekListVM.Van), zoekListVM.TerugDate);

            }
            else if (zoekListVM.Van == 7 || zoekListVM.Naar == 7) //Moskou - ? || ? - Moskou        stop: Berlijn
            {
                zoekListVM.RoutesHeen = routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Van), 5, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate);
                zoekListVM.RoutesTerug = routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Naar), 5, Convert.ToInt16(zoekListVM.Van), zoekListVM.TerugDate);

            }
            else
            {
                zoekListVM.RoutesHeen = routesService.GetTrainenBijVanEnNaarId(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate);
                zoekListVM.RoutesTerug = routesService.GetTrainenBijVanEnNaarId(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van), zoekListVM.HeenDate);
            }*/

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

        /*
        public IActionResult Passagiers(ZoekListVM zoekListVM, Decimal prijs)
        {
            return View(zoekListVM);
        }


        //TODO: DEZE CODE INORDE MAKEN
        //public IActionResult Boeken(ZoekListVM boek)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    routesService = new RoutesService();
        //    TreinRoutes route = routesService.Get(Convert.ToInt16(id));

        //    OverstappenVM deelItem = new OverstappenVM
        //    {
        //        Vertrek = 
        //    }

        //    CartVM item = new CartVM
        //    {
        //        Biernr = bier.Biernr,
        //        Aantal = 1,
        //        Prijs = 15,
        //        DateCreated = DateTime.Now,
        //        Naam = bier.Naam
        //    };

        //    ShoppingCartVM shopping;

        //    if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
        //    {
        //        shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
        //    }
        //    else
        //    {
        //        shopping = new ShoppingCartVM();
        //        shopping.Cart = new List<CartVM>();
        //    }

        //    shopping.Cart.Add(item);
        //    HttpContext.Session.SetObject("ShoppingCart", shopping);


        //    return RedirectToAction("Validatie", "Trein");
        //}


        public IActionResult RoutesStringFilter()
        {
            //var list = routesService.GetTreinenBijVertrek("Brussel");

            return View();
        }
        */
        
        /*
        public IActionResult AlleReismogelijkheden()
        {
            ReisMogelijkhedenService reisMogelijkhedenService = new ReisMogelijkhedenService();

            var list = reisMogelijkhedenService.GetAll();

            return View(list);
        }*/

        public IActionResult AlleRitten()
        {
            TrajectService trajectService = new TrajectService();

            var list = trajectService.GetRitten(Convert.ToInt16(1), Convert.ToInt16(7));

            return View(list);
        }

        public IActionResult AlleRittenVanTraject()
        {
            RittenService rittenService = new RittenService();

            var list = rittenService.GetRittenVanTraject(Convert.ToInt16(2), Convert.ToInt16(7));

            return View(list);
        }
    }
}

      




