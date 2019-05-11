using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Treinreizen.Domain.Entities;
using Treinreizen.Extensions;
using Treinreizen.Service;
using Treinreizen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinreizen.Controllers
{
    public class HotelController : Controller
    {
        HotelsService hotelsService = new HotelsService();
        public IActionResult Hotels(int stadId)
        {
            var hotelList = hotelsService.GetHotelsVanStad(stadId);
            return View(hotelList);
        }

        //CODE NOG NIET CORRECT

        public IActionResult Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            hotelsService = new HotelsService();
            Hotels hotel = hotelsService.Get(Convert.ToInt16(id));

            return View();

            //Order aanmaken?
            //HotelOrderVM item = new HotelOrderVM
            //{
            //    HotelNaam = hotel.Naam,
            //    StadNaam = hotel.Stad.Naam,
            //    Foto = hotel.Foto

            //};

            //HotelOrderVM hotelOrderVM;

            //if (HttpContext.Session.GetObject<HotelOrderVM>("ShoppingCart") != null)
            //{
            //    hotelOrderVM = HttpContext.Session.GetObject<HotelOrderVM>("ShoppingCart");
            //}
            //else
            //{
            //    hotelOrderVM = new HotelOrderVM();

            //}

            ////hotelOrderVM.Add(item);
            //HttpContext.Session.SetObject("ShoppingCart", hotelOrderVM);


            //return RedirectToAction("Index", "ShoppingCart");
        }





    }
}

    