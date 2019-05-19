using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
            TicketService ticketService = new TicketService();

            VakantiesService vakantiesService = new VakantiesService();

            zoekListVM.RoutesHeen = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));

            double totalePrijs = 0;

            foreach (var item in zoekListVM.RoutesHeen)
            {
                if (item.ReisMogelijkheden.Prijs != null)
                {
                    totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                }

                var vakantie = new Vakanties();
                var extraPlaatsen = 1.0;
                //controle vakantie
                if (item.ReisMogelijkheden.Kerstvakantie == true && vakantiesService.DatumInVakantie(Convert.ToDateTime(zoekListVM.HeenDate), true)==true)
                {
                    vakantie = vakantiesService.Get(Convert.ToDateTime(zoekListVM.HeenDate), true);
                    extraPlaatsen = 1 + vakantie.PercentExtraPlaatsen;
                }
                else if (item.ReisMogelijkheden.Paasvakantie == true && vakantiesService.DatumInVakantie(Convert.ToDateTime(zoekListVM.HeenDate), false)==true)
                {
                    vakantie = vakantiesService.Get(Convert.ToDateTime(zoekListVM.HeenDate), false);
                    extraPlaatsen = 1 + vakantie.PercentExtraPlaatsen;       
                }

                //controle nog genoeg plaatsen op de trein
                if (zoekListVM.Klasse == 1)
                {
                    var vrijePlaatsen = Convert.ToInt16(item.ReisMogelijkheden.Trein.AantalPlaatsenEc * extraPlaatsen) - ticketService.GetAantalPlaatsenGereserveerd(item.ReisMogelijkhedenId, Convert.ToDateTime(zoekListVM.HeenDate), zoekListVM.Klasse);

                    if (vrijePlaatsen < zoekListVM.Aantal)
                    {
                        return RedirectToAction("ErrorTreinOverboekt");
                    }
                }
                else
                {
                    var vrijePlaatsen = (item.ReisMogelijkheden.Trein.AantalPlaatsenBus * extraPlaatsen) - ticketService.GetAantalPlaatsenGereserveerd(item.ReisMogelijkhedenId, Convert.ToDateTime(zoekListVM.HeenDate), zoekListVM.Klasse);


                    if (vrijePlaatsen < zoekListVM.Aantal)
                    {
                        return RedirectToAction("ErrorTreinOverboekt");
                    }
                }
            }


            var aankomstdatumheenreis = Convert.ToDateTime(zoekListVM.HeenDate);

            //overstap gemist
            if (zoekListVM.RoutesHeen.Count() > 1)
            {
                for (int i = 0; i < zoekListVM.RoutesHeen.Count() - 1; i++)
                {
                    if (zoekListVM.RoutesHeen.ElementAt(i).ReisMogelijkheden.Aankomsttijd >= zoekListVM.RoutesHeen.ElementAt(i + 1).ReisMogelijkheden.Vertrektijd)
                    {
                        aankomstdatumheenreis = aankomstdatumheenreis.AddDays(1);
                    }
                }
            }
            ViewBag.Aankomstdatumheen = aankomstdatumheenreis;



            var aankomstdatumterugreis = Convert.ToDateTime(zoekListVM.TerugDate);

            if (zoekListVM.TerugDate != null)
            {
                zoekListVM.RoutesTerug = rittenService.GetRittenVanTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

                foreach (var item in zoekListVM.RoutesTerug)
                {
                    if (item.ReisMogelijkheden.Prijs != null)
                    {
                        totalePrijs += Convert.ToDouble(item.ReisMogelijkheden.Prijs);
                    }

                    var vakantie = new Vakanties();
                    var extraPlaatsen = 1.0;
                    //controle vakantie
                    if (item.ReisMogelijkheden.Kerstvakantie == true && vakantiesService.DatumInVakantie(Convert.ToDateTime(zoekListVM.TerugDate), true) == true)
                    {
                        vakantie = vakantiesService.Get(Convert.ToDateTime(zoekListVM.TerugDate), true);
                        extraPlaatsen = 1 + vakantie.PercentExtraPlaatsen;
                    }
                    else if (item.ReisMogelijkheden.Paasvakantie == true && vakantiesService.DatumInVakantie(Convert.ToDateTime(zoekListVM.TerugDate), false) == true)
                    {
                        vakantie = vakantiesService.Get(Convert.ToDateTime(zoekListVM.TerugDate), false);
                        extraPlaatsen = 1 + vakantie.PercentExtraPlaatsen;
                    }

                    //controle nog genoeg plaatsen op de trein
                    if (zoekListVM.Klasse == 1)
                    {
                        var vrijePlaatsen = Convert.ToInt16(item.ReisMogelijkheden.Trein.AantalPlaatsenEc * extraPlaatsen) - ticketService.GetAantalPlaatsenGereserveerd(item.ReisMogelijkhedenId, Convert.ToDateTime(zoekListVM.HeenDate), zoekListVM.Klasse);

                        if (vrijePlaatsen < zoekListVM.Aantal)
                        {
                            return RedirectToAction("ErrorTreinOverboekt");
                        }
                    }
                    else
                    {
                        var vrijePlaatsen = Convert.ToInt16(item.ReisMogelijkheden.Trein.AantalPlaatsenBus * extraPlaatsen) - ticketService.GetAantalPlaatsenGereserveerd(item.ReisMogelijkhedenId, Convert.ToDateTime(zoekListVM.HeenDate), zoekListVM.Klasse);

                        if (vrijePlaatsen < zoekListVM.Aantal)
                        {
                            return RedirectToAction("ErrorTreinOverboekt");
                        }
                    }
                }


                //overstap gemist
                if (zoekListVM.RoutesTerug.Count() > 1)
                {
                    for (int i = 0; i < zoekListVM.RoutesTerug.Count() - 1; i++)
                    {
                        if (zoekListVM.RoutesTerug.ElementAt(i).ReisMogelijkheden.Aankomsttijd >= zoekListVM.RoutesTerug.ElementAt(i + 1).ReisMogelijkheden.Vertrektijd)
                        {
                            aankomstdatumterugreis = aankomstdatumterugreis.AddDays(1);
                        }
                    }
                }

            }
            ViewBag.Aankomstdatumterug = aankomstdatumterugreis;

            ViewBag.PrijsTicket = Convert.ToDouble(totalePrijs);

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

        [HttpPost]
        public IActionResult Boeken(ZoekListVM zoekListVM, double prijs, string aankomstdatumheen, string aankomstdatumterug)
        {
            if (zoekListVM == null)
            {
                return NotFound();
            }

            TrajectService trajectService = new TrajectService();
            Traject trajectheen = trajectService.GetTraject(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar));

            KlasseService klasseService = new KlasseService();
            Klasse klasse = klasseService.GetKlasseVanId(zoekListVM.Klasse);

            double p = prijs * (1 + Convert.ToDouble(klasse.Toeslag)) * zoekListVM.Aantal;
            p = Math.Round(p, 2);

            List<string> vn = new List<string>();
            List<string> an = new List<string>();
            for (int i = 0; i < zoekListVM.Aantal; i++)
            {
                vn.Add(zoekListVM.Passagierslijst.Passagiers[i].Voornaam);
                an.Add(zoekListVM.Passagierslijst.Passagiers[i].Achternaam);
            }

            CartVM itemheen = new CartVM
            {
                TrajectId = trajectheen.TrajectId,
                Van = trajectheen.VertrekStadNavigation.Naam,
                Naar = trajectheen.AankomstStadNavigation.Naam,
                AantalTickets = zoekListVM.Aantal,
                Klasse = zoekListVM.Klasse,
                Prijs = p,
                Vertrekdatum = Convert.ToDateTime(zoekListVM.HeenDate),
                Aankomstdatum = Convert.ToDateTime(aankomstdatumheen),
                Voornamen = vn,
                Achternamen = an
                
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

            shopping.Cart.Add(itemheen);
            HttpContext.Session.SetObject("ShoppingCart", shopping);

            if (zoekListVM.TerugDate != null)
            {

                Traject trajectterug = trajectService.GetTraject(Convert.ToInt16(zoekListVM.Naar), Convert.ToInt16(zoekListVM.Van));

                double pterug = prijs * (1 + Convert.ToDouble(klasse.Toeslag)) * zoekListVM.Aantal;
                pterug = Math.Round(pterug, 2);

                CartVM itemterug = new CartVM
                {
                    TrajectId = trajectterug.TrajectId,
                    Van = trajectterug.VertrekStadNavigation.Naam,
                    Naar = trajectterug.AankomstStadNavigation.Naam,
                    AantalTickets = zoekListVM.Aantal,
                    Klasse = zoekListVM.Klasse,
                    Prijs = pterug,
                    Vertrekdatum = Convert.ToDateTime(zoekListVM.TerugDate),
                    Aankomstdatum = Convert.ToDateTime(aankomstdatumterug)
                };

                if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
                {
                    shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
                }
                else
                {
                    shopping = new ShoppingCartVM();
                    shopping.Cart = new List<CartVM>();
                }

                shopping.Cart.Add(itemterug);
                HttpContext.Session.SetObject("ShoppingCart", shopping);

            }

            return RedirectToAction("Index", "ShoppingCart");//return RedirectToAction("Passagiers", "ShoppingCart, new {aantalpassagiers = zoekListVM.Aantal}
        }

        [Route("/CustomErrorPages/Overboekt")]
        public IActionResult ErrorTreinOverboekt()
        {
            return View();
        }
    }
}






