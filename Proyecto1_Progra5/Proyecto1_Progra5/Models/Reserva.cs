using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdReserva")]
        public int Id { get; set; }

        public int UsuarioId { get; set; } // Cambia a int para representar la clave externa del usuario

        [ForeignKey("UsuarioId")] // Define la clave externa
        public virtual Usuario Usuario { get; set; } // Propiedad de navegación para el usuario

        [Required]
        [DisplayName("Fecha Reserva")]
        public DateTime FechaReserva { get; set; }

        [Required]
        [DisplayName("Ultimo Día De Pago")]
        public DateTime FechaFinalPago { get; set; }

        [Required]
        [DisplayName("A Cancelar")]
        public float Monto { get; set; }
    }

}