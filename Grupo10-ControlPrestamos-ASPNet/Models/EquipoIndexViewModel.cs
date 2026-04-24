using System.Collections.Generic;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class EquipoIndexViewModel
    {
        public string BuscarCliente { get; set; }

        public IReadOnlyList<HistorialPrestamo> Historial { get; set; }
    }
}
