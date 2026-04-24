using System.ComponentModel.DataAnnotations;

namespace Grupo10_ControlPrestamos_ASPNet.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contrasena es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasena")]
        public string Password { get; set; }
    }
}
