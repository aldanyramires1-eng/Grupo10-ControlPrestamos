using System;
using System.Web.Mvc;
using Grupo10_ControlPrestamos_ASPNet.Filters;
using Grupo10_ControlPrestamos_ASPNet.Models;
using Grupo10_ControlPrestamos_ASPNet.Repositories;

namespace Grupo10_ControlPrestamos_ASPNet.Controllers
{
    [SessionAuthorize]
    public class PrestamosController : Controller
    {
        private readonly PrestamoRepository repository = new PrestamoRepository();

        [HttpGet]
        public ActionResult Index(string buscarCliente, string estado)
        {
            var model = new PrestamoIndexViewModel
            {
                BuscarCliente = buscarCliente,
                Estado = estado,
                Prestamos = repository.GetPrestamos(buscarCliente, estado)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PrestamoCreateViewModel
            {
                FechaDevolucionEsperada = DateTime.Today.AddDays(1),
                Estado = "Prestado"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrestamoCreateViewModel model)
        {
            if (model.FechaDevolucionEsperada.Date <= DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.FechaDevolucionEsperada), "La fecha debe ser posterior a hoy.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.CreatePrestamo(model);
            TempData["SuccessMessage"] = "Prestamo guardado exitosamente en la base de datos.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Equipos(string buscarCliente)
        {
            var model = new EquipoIndexViewModel
            {
                BuscarCliente = buscarCliente,
                Historial = repository.GetHistorialPrestamos(buscarCliente)
            };

            return View(model);
        }
    }
}
