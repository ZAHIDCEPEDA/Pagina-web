using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pagina_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagina_web.Controllers
{
    public class InventariosController : Controller
    {
        // GET: InventariosController
        public ActionResult Index()
        {
            List<Inventario> ltsinventario = new List<Inventario>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Listapersonas")))
            {
                Inventario inv = new Inventario();
                inv.Nombre = "Zahid";
                inv.Apellido = "Cepeda";
                inv.Cedula = "1756624799";
                inv.Direccion = "Magdalena";
                inv.Genero = "Masculino";
                for (int i= 0; i < 10; i++)
                {
                ltsinventario.Add(inv);
                }
            }
            else
            {
                ltsinventario = JsonConvert.DeserializeObject<List<Inventario>>(HttpContext.Session.GetString("Listapersonas"));
            }
            HttpContext.Session.SetString("Listapersonas", JsonConvert.SerializeObject(ltsinventario));
               
            return View(ltsinventario);
        }

        // GET: InventariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventariosController/Create
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventario inventario)
        {
            try
            {
                List<Inventario> inven = new List<Inventario>();
                inven = JsonConvert.DeserializeObject<List<Inventario>>(HttpContext.Session.GetString("Listapersonas"));
                inven.Add(inventario);
                HttpContext.Session.SetString("Listapersonas", JsonConvert.SerializeObject(inven));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
