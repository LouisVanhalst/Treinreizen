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

        [HttpPost]
        public IActionResult Home(ZoekListVM zoekListVM)
        {
            ModelState.Clear();

            if (zoekListVM == null)
            {
                return NotFound();
            }

            StedenService stedenService = new StedenService();

            zoekListVM.Steden = new SelectList(stedenService.GetAll(), "StadId", "Naam");

            KlasseService klasseService = new KlasseService();
            zoekListVM.Klasses = new SelectList(klasseService.GetAll(), "KlasseId", "Klassenaam");
            zoekListVM.GeselecteerdeKlasse = klasseService.GetKlasseVanId(zoekListVM.Klasse);

            RittenService rittenService = new RittenService();
            TrajectService trajectService = new TrajectService();

            zoekListVM.RoutesHeen = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));
            //zoekListVM.TrajectId = trajectService.GetTrajectId(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));

            double totalePrijs = 0;

            foreach (var item in zoekListVM.RoutesHeen)
            {
                if (item.ReisMogelijkheden.Prijs != null)
                {
                    totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                }

            }

            if (zoekListVM.TerugDate != null)
            {
                zoekListVM.RoutesTerug = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

                foreach (var item in zoekListVM.RoutesTerug)
                {
                    if (item.ReisMogelijkheden.Prijs != null)
                    {
                        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                    }
                }
            }

            var aankomstdatumheenreis = zoekListVM.HeenDate;
            //overstap gemist (eerst sorteren dat de volgorde van de reismogelijkheden klopt)
            if (zoekListVM.RoutesHeen.Count() > 1)
            {
                for (int i = 0; i < zoekListVM.RoutesHeen.Count() - 1; i++)
                {
                    if (zoekListVM.RoutesHeen.ElementAt(i).ReisMogelijkheden.Aankomsttijd >= zoekListVM.RoutesHeen.ElementAt(i + 1).ReisMogelijkheden.Vertrektijd)
                    {
                        aankomstdatumheenreis = aankomstdatumheenreis + 1;
                    }
                }
            }



            ViewBag.PrijsTicket = Convert.ToDouble(totalePrijs);// * (1 + zoekListVM.GeselecteerdeKlasse.Toeslag));// Convert.ToDouble(zoekListVM.GeselecteerdeKlasse.Toeslag));

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
        public IActionResult Boeken(ZoekListVM zoekListVM, double prijs)
        {

            //if (boeken == null)
            //{
            //    return NotFound();
            //}

            TrajectService trajectService = new TrajectService();
            Traject traject = trajectService.GetTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));

            KlasseService klasseService = new KlasseService();
            Klasse klasse = klasseService.GetKlasseVanId(zoekListVM.Klasse);

            //double totalePrijs = 0;

            //foreach (var item in zoekListVM.RoutesHeen)
            //{
            //    if (item.ReisMogelijkheden.Prijs != null)
            //    {
            //        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
            //    }

            //}


            //foreach (var item in zoekListVM.RoutesTerug)
            //{
            //    if (item.ReisMogelijkheden.Prijs != null)
            //    {
            //        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
            //    }
            //}

            //ViewBag.PrijsTicket = (totalePrijs * zoekListVM.Aantal) * (1 + zoekListVM.GeselecteerdeKlasse.Toeslag);

            double p = prijs * (1 + Convert.ToDouble(klasse.Toeslag));
            p = Math.Round(p, 2);

            CartVM item = new CartVM
            {
                TrajectId = traject.TrajectId,
                Van = traject.VertrekStadNavigation.Naam,
                Naar = traject.AankomstStadNavigation.Naam,
                AantalTickets = zoekListVM.Aantal,
                Klasse = zoekListVM.Klasse,
                Prijs = p,
                Vertrekdatum = Convert.ToDateTime(zoekListVM.HeenDate),
                Aankomstdatum = Convert.ToDateTime(zoekListVM.HeenDate)
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

            if (zoekListVM.TerugDate != null)
            {
                //TrajectService trajectService = new TrajectService();
                Traject trajectterug = trajectService.GetTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

                //KlasseService klasseService = new KlasseService();
                //Klasse klasseterug = klasseService.GetKlasseVanId(zoekListVM.Klasse);

                //double totalePrijs = 0;

                //foreach (var item in zoekListVM.RoutesHeen)
                //{
                //    if (item.ReisMogelijkheden.Prijs != null)
                //    {
                //        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                //    }

                //}


                //foreach (var item in zoekListVM.RoutesTerug)
                //{
                //    if (item.ReisMogelijkheden.Prijs != null)
                //    {
                //        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                //    }
                //}

                //ViewBag.PrijsTicket = (totalePrijs * zoekListVM.Aantal) * (1 + zoekListVM.GeselecteerdeKlasse.Toeslag);

                double pterug = prijs * (1 + Convert.ToDouble(klasse.Toeslag));


                CartVM itemterug = new CartVM
                {
                    TrajectId = trajectterug.TrajectId,
                    Van = trajectterug.VertrekStadNavigation.Naam,
                    Naar = trajectterug.AankomstStadNavigation.Naam,
                    AantalTickets = zoekListVM.Aantal,
                    Klasse = zoekListVM.Klasse,
                    Prijs = pterug
                };


                //ShoppingCartVM shopping;

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

            }
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






