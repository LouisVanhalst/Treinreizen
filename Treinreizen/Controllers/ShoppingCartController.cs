using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Treinreizen.Extensions;
using Treinreizen.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Treinreizen.Services;
using Treinreizen.Domain.Entities;
using Treinreizen.Service;
using System.Data;

namespace Treinreizen.Controllers
{

    public class ShoppingCartController : Controller
    {

        public IActionResult Index()
        {
            //ShoppingCartVM shopping;

            //if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
            //{
            //    shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            //}
            //else
            //{
            //    shopping = new ShoppingCartVM();
            //    shopping.Cart = new List<CartVM>();

            //}

            //var SessionId = HttpContext.Session.Id;

            //return View(shopping);

            //OM ER VOOR TE ZORGEN DAT EMPTYCART WERKT:
            ShoppingCartVM cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            var SessionId = HttpContext.Session.Id;

            return View(cartList);
        }

        //nog de implementeren

        public ActionResult Delete(int? trajectId)
        {
            if (trajectId == null)
            {
                return NotFound();
            }

            ShoppingCartVM cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove = cartList.Cart.FirstOrDefault(r => r.TrajectId == trajectId);
            if (itemToRemove != null)
            {
                cartList.Cart.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }
            return View("Index", cartList);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(List<CartVM> cart, List<PassagierVM> passagiers)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            HotelsService hotelsService = new HotelsService();
            StatusService statusService = new StatusService();
            AspNetUsersService klantService = new AspNetUsersService();
            StedenService stedenService = new StedenService();
            OrderService orderService = new OrderService();
            KlasseService klasseService = new KlasseService();

            TicketService ticketService = new TicketService();

            try
            {
                var id = 0;
                Order geboekteOrder = new Order();

                foreach (CartVM c in cart)
                {
                    Order order = new Order();
                    order.Klant = klantService.Get(userID);
                    order.KlantId = userID;
                    order.AantalTickets = c.AantalTickets;
                    order.Klasse = klasseService.GetKlasseVanId(c.Klasse);
                    order.Prijs = (decimal)c.Prijs;
                    order.Status = statusService.Get(1);
                    order.StatusId = 1;
                    order.Boekingsdatum = DateTime.UtcNow;
                    order.TrajectId = c.TrajectId;
                    order.Aankomstdatum = c.Aankomstdatum;
                    order.Vertrekdatum = c.Vertrekdatum;
                    
                    orderService.Create(order);

                    geboekteOrder = orderService.Get(order.OrderId);
                    id = geboekteOrder.OrderId;

                    RittenService rittenService = new RittenService();
                    IEnumerable<Ritten> reisMogelijkhedenHeen = rittenService.GetRittenVanTrajectId(c.TrajectId);

                    
                    //aanmaken van tickets
                    for (int i = 0; i < c.AantalTickets; i++)
                    {
                        foreach (var item in reisMogelijkhedenHeen)
                        { 
                            Ticket ticket = new Ticket();

                            ticket.OrderId = id;
                            ticket.Zetelnummer = ticketService.GetAantalPlaatsenGereserveerd(item.ReisMogelijkhedenId, c.Vertrekdatum, c.Klasse) + 1;
                            ticket.VoornaamPassagier = "Sophie";
                            ticket.AchternaamPassagier = "De Waele";
                            ticket.ReismogelijkhedenId = item.ReisMogelijkhedenId;
                            ticketService.Create(ticket);
                        }
                    }


                }

                //aanmaken van tickets

                //foreach (PassagierVM p in passagiers)
                //{

                //    Ticket ticket = new Ticket();

                //    ticket.OrderId = id;
                //    //ticket.Zetelnummer = 
                //    //ticket.VoornaamPassagier =
                //    //ticket.AchternaamPassagier =
                //    //ticket.ReisMogelijkheden = 
                //    ticketService.Create(ticket);
                //}

                return RedirectToAction("Validation");

            }
            catch (DataException ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
            catch (Exception ex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "call system administrator.");

            }

            return View("Index");


        }

        public async Task<ActionResult> Validation()
        {
            var email = User.Identity.Name;

            if (email != null)
            {
                try
                {

                    var body = "<p> Email From: " + "{0} ({1})</p><p>Message:" + " </p><p>{2}</p>";
                    body = "de bestelling werd met succes uitgevoerd";

                    EmailSender mail = new EmailSender();
                    await mail.TaskEmailAsync(email, "Bevestiging Bestelling", body);

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                return RedirectToAction("/Account/Login", "Identity");
            }
            return View();
        }

        public IActionResult Passagiers()//int aantalPassagiers)
        {
            //ViewBag.AantalPassagiers = 3;

            PassagierslijstVM passagierslijst = new PassagierslijstVM();
            //passagierslijst.passagiers = new List<PassagierVM>();

            for (int i = 0; i < 3; i++)
            {
                PassagierVM passagier = new PassagierVM();
               // passagierslijst.passagiers.Add(passagier);
            }

            return View(passagierslijst);
        }

        [HttpPost]
        public IActionResult Passagiers(PassagierslijstVM passagierslijst)//int aantalPassagiers)
        {
            //PassagierslijstVM psl = new PassagierslijstVM();
            //passagierslijst.passagiers = new List<PassagierVM>();


            //foreach (var item in passagierslijst.passagiers)
            //{
            //    PassagierVM passagier = new PassagierVM();
            //    psl.passagiers.Add(item);
            //}

            //return View(psl);

            return RedirectToAction("Ps", passagierslijst);
        }

        public IActionResult Ps(PassagierslijstVM passagierslijst)
        {
            return View(passagierslijst);
        }
    }
}