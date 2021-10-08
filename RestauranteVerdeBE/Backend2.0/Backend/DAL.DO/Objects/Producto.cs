using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
