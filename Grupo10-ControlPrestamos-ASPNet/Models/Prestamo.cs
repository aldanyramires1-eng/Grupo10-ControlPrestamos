using System;
using System.ComponentModel.DataAnnotations;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Display(Name = "Nombre del Cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El artículo es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Artículo / Equipo")]
        public string Articulo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime FechaPrestamo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Esperada de Devolución")]
        public DateTime FechaDevolucionEsperada { get; set; }

        [Required]
        [StringLength(30)]
        public string Estado { get; set; }
    }
}