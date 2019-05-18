using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Treinreizen.Domain.Entities;
using Treinreizen.Service;
using Treinreizen.Services;
using Treinreizen.ViewModel;

namespace Treinreizen.Controllers
{
    public class AccountController : Controller
    {
        private OrderService orderService;
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult>  Wachtwoord(string gebruiker)
        //{
        //    var email = gebruiker;

        //    if (email != null)
        //    {
        //        try
        //        {

        //            var body = "<p> Email From: " + "{0} ({1})</p><p>Message:" + " </p><p>{2}</p>";
        //            body = "om je wachtwoord te veranderen, klik volgende link: ";

        //            EmailSender mail = new EmailSender();
        //            await mail.TaskEmailAsync(email, "Bevestiging Bestelling", body);
        //            return RedirectToAction("Validation", "ShoppingCart");

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("/Account/Login", "Identity");
        //    }
        //    return View();
        //}

        [Authorize]
        public IActionResult Index()
        {
            orderService = new OrderService();
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var orderlijst = orderService.GetAllOrdersVanKlant(userID);
            

            

            return View(orderlijst);
        }


        public ActionResult Annuleer(int? orderNr)
        {

            //if (orderNr == null)
            //{
            //    return NotFound();
            //}
            orderService = new OrderService();
            Order order = new Order();
            order = orderService.Get(orderNr);

            orderService.Delete(order);

            return RedirectToAction("index","Account");
        }
    }
}