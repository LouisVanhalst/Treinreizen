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

        [Authorize]
        public IActionResult Index()
        {
            orderService = new OrderService();
            string userID = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var orderlijst = orderService.GetAllOrdersVanKlant(userID);

            return View(orderlijst);
        }

        [Authorize]
        public ActionResult Annuleer(int orderNr)
        {

            if (orderNr == null)
            {
                return NotFound();
            }

            orderService = new OrderService();
            Order order = orderService.Get(Convert.ToInt16(orderNr));
            if (DateTime.Compare(Convert.ToDateTime(order.Vertrekdatum), DateTime.Now.AddDays(3)) > 0)
            { 
                order.StatusId = 3;
                orderService.Update(order);
            }

            return RedirectToAction("index", "Account");
        }

        [Authorize]
        public ActionResult Details(int orderNr)
        {
            orderService = new OrderService();
            Order order = orderService.Get(Convert.ToInt16(orderNr));

            RittenService rittenService = new RittenService();

            ViewBag.ReisMogelijkheden = rittenService.GetRittenVanTrajectId(Convert.ToInt16(order.TrajectId));

            return View(order);
        }
    }
}