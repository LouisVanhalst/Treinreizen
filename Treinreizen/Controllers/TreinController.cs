using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Treinreizen.Service;
using Treinreizen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinreizen.Controllers
{
    public class TreinController : Controller
    {
        private StedenService stedenService;

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Home()
        {
            //ViewBag.lstSteden = new SelectList(stedenService.GetAll(),"StadId","Naam");
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

        //DATA TYPE NIET JUIST dateTime  & Date bij view?
        public IActionResult RouteMetFilter()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult RouteMetFilter(DateTime vertrek)
        {
            if (vertrek == null)
            {
                return NotFound();
            }
            var routeList = routesService.GetTreinenBijVertrek(vertrek);
            return View(vertrek);

        }

        public IActionResult Steden()
        {
            var list = stedenService.GetAll();
            return View(list);
        }

}
}
