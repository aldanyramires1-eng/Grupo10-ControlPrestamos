using System;
using System.ComponentModel.DataAnnotations;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class HistorialPrestamo
    {
        [Key]
        [Display(Name = "ID")]
        public int IdPrestamo { get; set; }

        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "Artículo")]
        public string Articulo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime FechaPrestamo { get; set; }
    }
}