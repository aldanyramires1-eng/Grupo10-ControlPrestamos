using System.Collections.Generic;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class PrestamoIndexViewModel
    {
        public string BuscarCliente { get; set; }

        public string Estado { get; set; }

        public IReadOnlyList<Prestamo> Prestamos { get; set; }
    }
}
