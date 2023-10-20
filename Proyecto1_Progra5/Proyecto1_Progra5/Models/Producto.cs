using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto1_Progra5.Models
{
    public class Producto
    {
        [Key] public int IDProducto { get; set; }
        [Required] public string Nombre { get; set; }
        [Required] public string Foto { get; set; }
        [Required] public float Precio { get; set; }
        [Required] public string Descripcion { get; set; }
    }
}
