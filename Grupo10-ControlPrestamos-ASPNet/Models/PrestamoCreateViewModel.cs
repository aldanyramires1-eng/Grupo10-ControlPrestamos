using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class PrestamoCreateViewModel
    {
        private static readonly string[] articulos = new[]
        {
            "Teclado Sintetizador",
            "Proyector Epson",
            "Libro de C#",
            "Cable HDMI",
            "Laptop Dell",
            "Tablet Samsung"
        };

        private static readonly string[] estados = new[]
        {
            "Prestado",
            "Devuelto",
            "Atrasado"
        };

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un articulo.")]
        [Display(Name = "Articulo / Equipo")]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "La fecha de devolucion es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha esperada de devolucion")]
        public DateTime FechaDevolucionEsperada { get; set; }

        [Required]
        [Display(Name = "Estado inicial")]
        public string Estado { get; set; }

        public IReadOnlyList<string> ArticulosDisponibles => articulos;

        public IReadOnlyList<string> EstadosDisponibles => estados;
    }
}
