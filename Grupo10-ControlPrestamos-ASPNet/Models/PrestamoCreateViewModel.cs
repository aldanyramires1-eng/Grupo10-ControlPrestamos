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

        [Required(ErrorMessage = "El nombre del cliente es absolutamente obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un artículo de la lista.")]
        [Display(Name = "Artículo / Equipo")]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "La fecha de devolución es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha esperada de devolución")]
        public DateTime FechaDevolucionEsperada { get; set; }

        [Required(ErrorMessage = "El estado inicial no puede quedar vacío.")]
        [Display(Name = "Estado inicial")]
        public string Estado { get; set; }

        public IReadOnlyList<string> ArticulosDisponibles => articulos;
        public IReadOnlyList<string> EstadosDisponibles => estados;
    }
}