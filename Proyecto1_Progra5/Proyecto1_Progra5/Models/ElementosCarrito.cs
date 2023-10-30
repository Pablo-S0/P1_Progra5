using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class ElementosCarrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdElementosCarrito")]
        public int Id { get; set; }
        [Required] public int Cantidad { get; set; }
        [Required] public int SubTotal { get; set; }
        public Carrito Carrito { get; set; }
        public Producto Productos { get; set; }
    }
}
