using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_app.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbConetext _Context;
        public CinemasController(AppDbConetext Context)
        {
            _Context = Context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Context.Cenimas.ToListAsync();
            return View(data);
        }
    }
}
