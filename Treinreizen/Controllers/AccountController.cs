using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Treinreizen.Service;
using Treinreizen.Services;

namespace Treinreizen.Controllers
{
    public class AccountController : Controller
    {
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
            OrderService orderService = new OrderService();
            var orderlijst = orderService.GetAll();

            return View(orderlijst);
        }
    }
}