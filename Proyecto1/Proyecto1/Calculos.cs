using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraAPI.Models
{
    public class Calculos
    {
        public int Id { get; set; }
        public string Operacion { get; set; }
        public decimal Resultado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
