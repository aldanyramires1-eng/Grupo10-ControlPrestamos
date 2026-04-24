using System;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }

        public string NombreCliente { get; set; }

        public string Articulo { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucionEsperada { get; set; }

        public string Estado { get; set; }
    }
}
