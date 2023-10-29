using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proyecto1_Progra5.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdUsuario")]
        public int Id { get; set; }
        [Required] public string Correo { get; set; }
        [Required] public string Clave { get; set; }
        [Required] public string NombreCompleto { get; set; }
        [Required] public string Telefono { get; set; }

        //public Rol Rol { get; set; } 


    }
}
