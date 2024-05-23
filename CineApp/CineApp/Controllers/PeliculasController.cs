using CineApp.Daos;
using CineApp.Dtos;
using CineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineApp.Controllers
{
    public class PeliculasController : Controller {

        private PeliculaDao PeliculaDao;
        private int TotalRegsTabla { get; set; }

        private List<SelectListItem> Options = new List<SelectListItem>{
                new SelectListItem { Value = "5", Text = "5" },
                new SelectListItem { Value = "10", Text = "10" },
                new SelectListItem { Value = "15", Text = "15" }
        };

        public PeliculasController() { 
            this.PeliculaDao = new PeliculaDao();
            this.TotalRegsTabla = PeliculaDao.contarPeliculas();
        }

        // GET: Peliculas
        [HttpGet]
        public ActionResult Index() {
            List<Pelicula> peliculas = PeliculaDao.obtenerPeliculas(1, 5);
            foreach (var pelicula in peliculas) {
                pelicula.Sinopsis = pelicula.Sinopsis.Substring(0, 40);
            }
            Paginador<Pelicula> paginador = new Paginador<Pelicula>(TotalRegsTabla, peliculas, 1, 5);
            ViewBag.Paginador = paginador;
            ViewBag.Options = this.Options;
            return View(peliculas);
        }

        // GET: Peliculas/Paginador
        [HttpGet]
        public ActionResult Paginador(int pagina, int cantRegs) {
            List<Pelicula> peliculas = PeliculaDao.obtenerPeliculas(pagina, cantRegs);
            foreach (var pelicula in peliculas) {
                pelicula.Sinopsis = pelicula.Sinopsis.Substring(0, 40);
            }
            Paginador<Pelicula> paginador = new Paginador<Pelicula>(TotalRegsTabla, peliculas, pagina, cantRegs);
            ViewBag.Paginador = paginador;
            foreach (SelectListItem option in this.Options) { 
                if (Convert.ToInt32(option.Value) == cantRegs) {
                    option.Selected = true;
                }
            }
            ViewBag.Options = this.Options;
            return View(peliculas);
        }

        // GET: Peliculas/ModificarForm
        [HttpGet]
        public ActionResult ModificarForm(int id) {

            try {
                Pelicula pelicula = PeliculaDao.obtenerPelicula(id);
                return View(pelicula);
            } catch {
                return View();
            }

        }

        // POST: Peliculas/Modificar
        [HttpPost]
        public ActionResult Modificar(Pelicula pelicula) {

            try {
                PeliculaDao.ModificarPelicula(pelicula);
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
        
    }
}