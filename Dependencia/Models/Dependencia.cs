using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dependencia.Models
{
    public class Dependencia
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string NombreDependencia { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
    }
}
