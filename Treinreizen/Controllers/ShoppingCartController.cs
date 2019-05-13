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
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Payment(List<CartVM> cart)
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
                    return RedirectToAction("Validation","ShoppingCart");
                   
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
            //string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //try
            //{

            //    //call method to save
            //}
            //catch (Exception ex)
            //{ }
        }

       

    }
}