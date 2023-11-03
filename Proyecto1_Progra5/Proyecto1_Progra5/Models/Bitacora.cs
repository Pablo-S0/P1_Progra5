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
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        [Required]
        public DateTime FechaHoraInicio { get; set; }
        [Required]
        public DateTime FechaHoraFinal { get; set; }

        [Required] public String Descripcion { get; set; }






    }
}
