using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_app.Data;
using Movie_app.Data.Services;
using Movie_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_app.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _Service;
        public ActorsController(IActorsService Service)
        {
            _Service= Service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Service.GetAllAsync();
            return View(data);
        }
        //Get :Actor/Create
        public IActionResult Create()
        {
            return View();
        }
        //Post :Actor/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Get: Actors Details
        public async Task<IActionResult> Details(int id)
        {
            var DetailsActor = await _Service.GetIdAsync(id);
            if (DetailsActor == null)
                return View("NotFound");
            return View(DetailsActor);
        }

        //Get :Actor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ActorEdit = await _Service.GetIdAsync(id);
            if (ActorEdit == null)
                return View("NotFound");
            return View(ActorEdit);
        }
        //Post :Actor/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }


        //Get :Actor/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ActorEdit = await _Service.GetIdAsync(id);
            if (ActorEdit == null)
                return View("NotFound");
            return View(ActorEdit);
        }
        //Post :Actor/Delete
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var ActorEdit = await _Service.GetIdAsync(id);
            if (ActorEdit == null)
                return View("NotFound");
            await _Service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
