using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdCarrito")] 
        public int Id { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Los valores de Estado son unicamente 1, 2, 3")] 
        public int Estado { get; set; }
        [Required] public Boolean Proyector { get; set; }
        [Required] public Boolean Computador { get; set; }
        [Required] public Boolean Realizado { get; set; }

    }
}
