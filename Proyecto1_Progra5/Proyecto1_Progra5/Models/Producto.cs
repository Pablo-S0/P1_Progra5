﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto1_Progra5.Models
{
    public class Producto
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("IdProducto")]*/
        public int Id { get; set; }
        [Required] public string Nombre { get; set; }
        public byte[] Foto { get; set; }
        [Required] public float Precio { get; set; }
        [Required] public string Descripcion { get; set; }
        [Required] public int Tipo { get; set; }
        //public List<ElementosCarrito> ElementosCarrito { get; set; }
    }
}
