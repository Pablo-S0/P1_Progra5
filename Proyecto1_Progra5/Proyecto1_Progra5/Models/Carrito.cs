using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto1_Progra5.Models
{
    public class Carrito
    {
        [Key] public int IDCarrito { get; set; }
        [Required] public int IDUsuario { get; set; }
        [Required] public int IDReserva { get; set; }
        
        [Required]
        [Range(1, 2, ErrorMessage = "Los valores de Estado son unicamente 1 o 2")] 
        public int Estado { get; set; }
    }
}
