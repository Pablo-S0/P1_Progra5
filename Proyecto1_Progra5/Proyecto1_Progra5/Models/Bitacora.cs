using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class Bitacora
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdBitacora")]
        public int Id { get; set; }
        [Required] public DateTime FechaHora { get; set; }
        [Required] public String Descripcion { get; set; }
        public Usuario Usuario { get; set; }

    }
}
