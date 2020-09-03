using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FARTSLAM.Data;
using FARTSLAM.Models;
using FARTSLAM.Models.Entities;

namespace FARTSLAM.Controllers
{
    public class CovidController : Controller
    {
        private FARTSLAMDBContext db;

        
        public CovidController() {
            this.db = new FARTSLAMDBContext();
            
        }

        public IActionResult Index()
        {
            CovidOptOutViewModel vm = new CovidOptOutViewModel();


            return View(vm);
        }
    }
}