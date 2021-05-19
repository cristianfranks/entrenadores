using System.Linq;
using entrenadores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace entrenadores.Controllers
{
    public class EntrenadorController : Controller
    {
        private readonly EntrenadorContext _context;

        public EntrenadorController(EntrenadorContext context) {
            _context = context;
        }
         public IActionResult Pueblos() {
             var pueblos = _context.Pueblos.Include(x => x.Entrenadores).OrderBy(e => e.Nombre).ToList();
             return View(pueblos);
         }
        public IActionResult Entrenadores() {
             var entrenadores = _context.Entrenadores.Include(x => x.Pueblo).OrderBy(e => e.Nombre).ToList();
             return View(entrenadores);
         }


         public IActionResult NuevoEntrenador() {
            ViewBag.Regiones = _context.Pueblos.ToList().Select(e => new SelectListItem(e.Nombre, e.Id.ToString()));
            return View();
        }
         [HttpPost]
        public IActionResult NuevoEntrenador(Entrenador e) {
            if (ModelState.IsValid) {
                _context.Add(e);
                _context.SaveChanges();
                return RedirectToAction("NuevoEntrenadorConfirmacion");
            }
            return View(e);
        }

        public IActionResult NuevoEntrenadorConfirmacion() {
            return View();
        }
        public IActionResult NuevoPueblo() {
            return View();
        }
         [HttpPost]
        public IActionResult NuevoPueblo(Pueblo e) {
            if (ModelState.IsValid) {
                _context.Add(e);
                _context.SaveChanges();
                return RedirectToAction("NuevoPuebloConfirmacion");
            }
            return View(e);
        }
        public IActionResult NuevoPuebloConfirmacion() {
            return View();
        }


        [HttpPost]
        public IActionResult BorrarPueblo(int id) {
            var pueblo = _context.Pueblos.Find(id);
            _context.Remove(pueblo);
            _context.SaveChanges();

            return RedirectToAction("Pueblos");
        }


        public IActionResult EditarPueblo(int id) {
            var pueblo = _context.Pueblos.Find(id);
            return View(pueblo);
        }

        [HttpPost]
        public IActionResult EditarPueblo(Pueblo e) {
            if (ModelState.IsValid) {
                var pueblo = _context.Pueblos.Find(e.Id);
                pueblo.Nombre = e.Nombre;
                _context.SaveChanges();
                return RedirectToAction("EditarPuebloConfirmacion");
            }
            return View(e);
        }

        public IActionResult EditarPuebloConfirmacion() {
            return View();
        }
    }
}