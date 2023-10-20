using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class Reserva
    {

        [Key] public int IDReserva { get; set; }
        [Required] public int IDUsuario { get; set; }
        [ForeignKey("IDUsuario")]
        public virtual Usuario Usuario { get; set; }
        [Required] public DateTime FechaReserva { get; set; }
        [Required] public DateTime FechaFinalPago { get; set; }
        [Required] public float Monto { get; set; }
        [Required] public Boolean Realizado { get; set; }
    }
}
