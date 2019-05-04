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

namespace Treinreizen.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {

            ShoppingCartVM cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            var SessionId = HttpContext.Session.Id;


            return View(cartList);
        }

        //nog de implementeren

        public ActionResult Delete(int? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }
            ShoppingCartVM cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            var itemToRemove = cartList.Cart.FirstOrDefault(r => r.OrderId == orderId);
            if (itemToRemove != null)
            {
                cartList.Cart.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }
            return View("Index", cartList);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Payment(List<CartVM> cart)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {

                //call method to save
            }
            catch (Exception ex)
            { }
            return View();
        }
    }
}