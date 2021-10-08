using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependencia.Models
{
    public class DependenciaEmpleados
    {
        public string NombreDependencia { get; set; }
        public string Direccion { get; set; }
        public List<Empleado> empleados { get; set; }
    }
}
