using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto1_Progra5.Models
{
    public class ElementosCarrito
    {

        [Required] public int IDECarrito { get; set; }
        [Required] public int IDCarrito { get; set; }
        [Required] public int IDProducto { get; set; }
        [Required] public int Cantidad { get; set; }
        [Required] public int SubTotal { get; set; }

    }
}
