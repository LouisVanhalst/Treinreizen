using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Treinreizen.Domain.Entities;
using Treinreizen.Service;
using Treinreizen.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Treinreizen.Controllers
{
    public class TreinController : Controller
    {
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
        public IActionResult Route()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Route(string vertrek)
        {

            if (vertrek == null)
            {
                return NotFound();
            }
            var routeList = routesService.GetTreinenBijVertrek(vertrek);
            return View(routeList);
        }


        public IActionResult Steden()
        {
            StedenService stedenService = new StedenService();
            var list = stedenService.GetAll();
            return View(list);
        }

        public IActionResult ReisMogelijkheden()
        {
            ReisMogelijkhedenService reisMogelijkhedenService = new ReisMogelijkhedenService();
            var list = reisMogelijkhedenService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Home()
        {
            StedenService stedenService = new StedenService();

            ZoekListVM zoekListVM = new ZoekListVM();

            zoekListVM.Steden = new SelectList(stedenService.GetAll(), "StadId", "Naam");

            return View(zoekListVM);
        }

        [HttpPost (Name ="Zoek Route")]
        
        public IActionResult Home(ZoekListVM zoekListVM)
        {
            ModelState.Clear();

            if (zoekListVM == null)
            {
                return NotFound();
            }

            /**if (zoekListVM.Van == zoekListVM.Naar)
            {
                return NotFound(); liever foutboodschap
            }**/

            StedenService stedenService = new StedenService();

            routesService = new RoutesService();
            zoekListVM.Steden = new SelectList(stedenService.GetAll(), "StadId", "Naam");

            /*
             * 1 Brussel
             * 2 Londen
             * 3 Parijs
             * 4 Amsterdam
             * 5 Berlijn
             * 6 Rome
             * 7 Moskou
            */

            
            
                if (zoekListVM.Van == 2 && zoekListVM.Naar == 7) //Londen - Moskou      stop: Brussel + Berlijn
            {
                zoekListVM.Routes = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Van), 1, 5, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate, zoekListVM.TerugDate);
            }
            else if (zoekListVM.Van == 7 && zoekListVM.Naar == 2) //Moskou - Londen stop: Berlijn + Brussel
            {
                zoekListVM.Routes = routesService.GetTrainenBijVanEnNaarId2Stops(Convert.ToInt16(zoekListVM.Van), 5, 1, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate, zoekListVM.TerugDate);
            }
            else if (zoekListVM.Van == 2 || zoekListVM.Naar == 2 || (zoekListVM.Van == 4 && zoekListVM.Naar == 3)
                || (zoekListVM.Van == 3 && zoekListVM.Naar == 4) || (zoekListVM.Van == 4 && zoekListVM.Naar == 6)
                || (zoekListVM.Van == 6 && zoekListVM.Naar == 4))
            //Londen - ?  || ? - Londen || Amsterdam - Parijs || Parijs - Amsterdam || Amsterdam - Rome || Rome - Amsterdam     stop: Brussel
            {
                zoekListVM.Routes = routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Van), 1, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate, zoekListVM.TerugDate);
            }
            else if (zoekListVM.Van == 7 || zoekListVM.Naar == 7) //Moskou - ? || ? - Moskou        stop: Berlijn
            {
                zoekListVM.Routes = routesService.GetTrainenBijVanEnNaarId1Stop(Convert.ToInt16(zoekListVM.Van), 5, Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate, zoekListVM.TerugDate);
            }
            else
            {
                zoekListVM.Routes = routesService.GetTrainenBijVanEnNaarId(Convert.ToInt16(zoekListVM.Van), Convert.ToInt16(zoekListVM.Naar), zoekListVM.HeenDate, zoekListVM.TerugDate);
            }

            if (ModelState.IsValid)
            {
                return View(zoekListVM);
            }
            else
            {
                zoekListVM.Routes = null;
                return View("Home",zoekListVM);
            }
        }
        






        }



}

