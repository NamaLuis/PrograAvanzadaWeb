using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Empleado
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
