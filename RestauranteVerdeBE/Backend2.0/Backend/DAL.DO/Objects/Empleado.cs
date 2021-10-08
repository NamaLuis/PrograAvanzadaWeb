using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Empleado
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int IdPuesto { get; set; }
        public int Salario { get; set; }
        public DateTime FechaContratacion { get; set; }

        public virtual Puesto IdPuestoNavigation { get; set; }
    }
}
