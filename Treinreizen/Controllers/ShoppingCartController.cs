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
        private OrderService orderService;

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
        public IActionResult Payment(List<CartVM> cart)
        {
            HashSet<Ticket> tickets = new HashSet<Ticket>();
            HashSet<TreinenVanOrder> treinen = new HashSet<TreinenVanOrder>();


            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            HotelsService hotelsService = new HotelsService();
            StatusService statusService = new StatusService();
            AspNetUsersService klantService = new AspNetUsersService();
            StedenService stedenService = new StedenService();
            orderService = new OrderService();
                       
            try
            {
                
                Order order;
                foreach (CartVM c in cart)
                {
                    order = new Order();
                    order.Klant = klantService.Get(userID);
                    order.KlantId = userID;
                    //order.OrderId = 1;
                    order.AantalTickets = c.AantalTickets;
                    order.Class = c.Class;
                    order.Prijs = (decimal) c.Prijs;
                    order.Hotel = hotelsService.Get(1);
                    order.Hotel.Stad = stedenService.Get(hotelsService.Get(1).StadId);
                    order.HotelId = 1;
                    order.Status = statusService.Get(1);
                    order.StatusId = 1;
                    order.Boekingsdatum = DateTime.UtcNow;

                    //treinen opvullen
                    //tickets opvullen

                    order.TreinenVanOrder = treinen;
                    order.Ticket = tickets;


                    orderService.Create(order);

                    //hotelsService.Update(order.Hotel);
                    //statusService.Update(order.Status);
                    //klantService.Update(order.Klant);
                    //stedenService.Update(order.Hotel.Stad);

                    
                }
                
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

        public async Task<ActionResult>  Validation()
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
            passagierslijst.passagiers = new List<PassagierVM>();

            for (int i = 0; i < 3; i++)
            {
                PassagierVM passagier = new PassagierVM();
                passagierslijst.passagiers.Add(passagier);
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