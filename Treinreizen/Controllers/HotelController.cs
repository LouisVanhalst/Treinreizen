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

        public IActionResult Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            hotelsService = new HotelsService();
            Hotels hotel = hotelsService.Get(Convert.ToInt16(id));

            return View();

        }





    }
}

