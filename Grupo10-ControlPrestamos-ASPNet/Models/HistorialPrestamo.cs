using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class HistorialPrestamo
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

        public int IdHistorial { get; set; }
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string NombreCliente { get; set; }

        [Display(Name = "Artículo")]
        public string Articulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaPrestamo { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de devolucion esperada es obligatoria.")]
        public DateTime FechaDevolucionEsperada { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de devolucion es obligatoria.")]
        public DateTime FechaDevolucion { get; set; }

        public string EstadoFinal { get; set; }

        public IReadOnlyList<string> ArticulosDisponibles => articulos;

        public IReadOnlyList<string> EstadosDisponibles => estados;
    }
}