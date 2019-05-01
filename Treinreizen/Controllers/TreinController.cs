using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Treinreizen.Service;
using Treinreizen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinreizen.Controllers
{
    public class TreinController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Home(ZoekVM zoekVM)
        {
            return View();
        }
        // GET: /<controller>/
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
        private RoutesService routesService;
        public TreinController()
        {
            routesService = new RoutesService();
        }

        public IActionResult Route()
        {
            var lijst = routesService.GetAll();
            return View(lijst);
        }
    

}
}
