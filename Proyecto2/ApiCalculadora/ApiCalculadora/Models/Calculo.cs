using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCalculadora.Models
{
    [Table("Calculos")]
    public class Calculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Operacion { get; set; }

        [Required]
        public decimal Resultado { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}
