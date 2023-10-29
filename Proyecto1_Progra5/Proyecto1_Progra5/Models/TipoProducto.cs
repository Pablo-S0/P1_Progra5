using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyecto1_Progra5.Models
{
    public class TipoProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdTipoProducto")]
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }
    }
}
