using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Empleado : ICRUD<data.Empleado>
    {
        private restauranteVerdeContext context;

        public Empleado(restauranteVerdeContext _context)
        {
            context = _context;
        }
        public void Delete(data.Empleado t)
        {
            new DAL.Empleado(context).Delete(t);
        }

        public IEnumerable<data.Empleado> GetAll()
        {
            return new DAL.Empleado(context).GetAll();
        }

        public async Task<IEnumerable<data.Empleado>> GetAllWithAsync()
        {
            return await new DAL.Empleado(context).GetAllWithAsync();
        }

        public data.Empleado GetOneByID(int id)
        {
            return new DAL.Empleado(context).GetOneByID(id);
        }

        public async Task<data.Empleado> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Empleado(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Empleado t)
        {
            new DAL.Empleado(context).Insert(t);
        }

        public void Update(data.Empleado t)
        {
            new DAL.Empleado(context).Update(t);
        }
    }
}
