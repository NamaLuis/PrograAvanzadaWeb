using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Puesto
    {
        public Puesto()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
