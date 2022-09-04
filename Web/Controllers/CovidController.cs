using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TOOTBLAN.Data;
using TOOTBLAN.Models;
using TOOTBLAN.Models.Entities;

namespace TOOTBLAN.Controllers
{
    public class CovidController : Controller
    {
        private TOOTBLANDBContext db;

        
        public CovidController() {
            this.db = new TOOTBLANDBContext();
            
        }

        public IActionResult Index()
        {
            CovidOptOutViewModel vm = new CovidOptOutViewModel();


            return View(vm);
        }
    }
}