using System;
using System.Text;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public interface IRepositoryEmpleado : IRepository<data.Empleado>
    {
       
            Task<IEnumerable<data.Empleado>> GetAllWithAsAsync();
            Task<data.Empleado> GetOneByIdAsAsync(int id);
        
    }
}
