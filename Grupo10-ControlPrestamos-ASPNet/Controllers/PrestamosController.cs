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

        #region Prestamos
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

        public ActionResult EditPrestamos(int idPrestamo)
        {
            var model = repository.GetPrestamos(idPrestamo);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPrestamos(PrestamoCreateViewModel model)
        {
            if (model.FechaDevolucionEsperada.Date <= DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.FechaDevolucionEsperada), "La fecha debe ser posterior a hoy.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.EditPrestamos(model);
            TempData["SuccessMessage"] = "Prestamo guardado exitosamente en la base de datos.";

            return RedirectToAction("Index");
        }

        public ActionResult DeletePrestamos(int idPrestamo) // El parámetro se llama idHistorial
        {
            repository.DeletePrestamos(idPrestamo);
            TempData["SuccessMessage"] = "Prestamo eliminado exitosamente en la base de datos.";

            return RedirectToAction("Index");
        }

        #endregion


        #region Equipos
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

        public ActionResult CreateEquipos()
        {
            return View(new HistorialPrestamo
            {
                FechaDevolucionEsperada = DateTime.Today.AddDays(1),
                EstadoFinal = "Prestado"
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEquipos(HistorialPrestamo model)
        {
            model.IdPrestamo = 1;
            if (model.FechaDevolucionEsperada.Date <= DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.FechaDevolucionEsperada), "La fecha debe ser posterior a hoy.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.CreateHistorialPrestamo(model);
            TempData["SuccessMessage"] = "Equipo guardado exitosamente en la base de datos.";

            return RedirectToAction("Equipos");
        }

        public ActionResult EditHistorialPrestamos(int IdHistorial)
        {
            var model = repository.GetHistorialPrestamos(IdHistorial);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHistorialPrestamos(HistorialPrestamo model)
        {
            if (model.FechaDevolucionEsperada.Date <= DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.FechaDevolucionEsperada), "La fecha debe ser posterior a hoy.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            repository.EditHistorialPrestamos(model);
            TempData["SuccessMessage"] = "Equipo guardado exitosamente en la base de datos.";

            return RedirectToAction("Equipos");
        }

        public ActionResult DeleteHistorialPrestamos(int IdHistorial)
        {
            repository.DeleteHistorialPrestamos(IdHistorial);
            TempData["SuccessMessage"] = "Equipo eliminado exitosamente en la base de datos.";

            return RedirectToAction("Equipos");
        }



        #endregion
    }
}
