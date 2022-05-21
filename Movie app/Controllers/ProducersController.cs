using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_app.Data;
using Movie_app.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _Service;
        public ProducersController(IProducerService Service)
        {
            _Service = Service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Service.GetAllAsync();
            return View(data);
        }  
        public async Task<IActionResult> Details(int id)
        {
            var pro = await _Service.GetIdAsync(id);
            if (pro == null)
                return View("NotFound");
            return View(pro);
        }
        //Get : Create/
    }
}
