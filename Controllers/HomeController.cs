using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto7.Models;
using Proyecto7.Permisos;

namespace Proyecto7.Controllers
{
    public class HomeController : Controller
    {
        /*
     Antes que se ejecute cualquier método del controlador principal
    Se ejecuta la logica de la clase ValidarSessionAttributte
     */
        [ValidarSessionAttributte]
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            return View(ma.RecuperarTodos());
        }

        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;//Empting Session User
            return RedirectToAction("Login", "Acceso");// Redirect to Login
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"]),
                Descripcion = collection["descripcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Alta(art);
            return RedirectToAction("Index");
        }
        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = id,
                Descripcion = collection["descripcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)

        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(id);
            return View(art);
        }
    }
}
