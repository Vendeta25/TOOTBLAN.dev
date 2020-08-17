using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MLBApp.Data;

namespace MLBApp.Controllers
{
    public class CovidController : Controller
    {
        private FARTSLAMDBContext db;
        
        public CovidController() {
            this.db = new FARTSLAMDBContext();
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}