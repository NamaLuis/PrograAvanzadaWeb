using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{ 
        public  class Cliente
        {
            public int Cedula { get; set; }
            public string Nombre { get; set; }
            public string Apellido1 { get; set; }
            public string Apellido2 { get; set; }
            public DateTime FechaCompra { get; set; }
        }
    }

