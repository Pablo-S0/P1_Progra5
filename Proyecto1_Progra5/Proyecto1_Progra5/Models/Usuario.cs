using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto1_Progra5.Models
{
    public class Usuario
    {
        [Key] public int IDUsuario { get; set; }
        [Required] public string Correo { get; set; }
        [Required] public string Clave { get; set; }
        [Required] public string NombreCompleto { get; set; }
        [Required] public string Telefono { get; set; }

        [Required]
        [Range(1,2, ErrorMessage ="Los valores de rol son unicamente 1 o 2")]
        public int Rol {  get; set; }//1 = administrador, 2 = Usuario o cliente


    }
}
