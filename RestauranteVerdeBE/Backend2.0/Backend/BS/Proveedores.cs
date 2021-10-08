using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
namespace BS
{
    public class Proveedores : ICRUD<data.Proveedores>
    {
        private restauranteVerdeContext context;
        public Proveedores(restauranteVerdeContext _context)
        {
            context = _context;
        }

        public void Delete(data.Proveedores t)
        {
            new DAL.Proveedores(context).Delete(t);
        }

        public IEnumerable<data.Proveedores> GetAll()
        {
            return new DAL.Proveedores(context).GetAll();
        }

        public Task<IEnumerable<data.Proveedores>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Proveedores GetOneByID(int id)
        {
            return new DAL.Proveedores(context).GetOneByID(id);
        }

        public Task<data.Proveedores> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Proveedores t)
        {
            new DAL.Proveedores(context).Insert(t);
        }

        public void Update(data.Proveedores t)
        {
            new DAL.Proveedores(context).Update(t);
        }
    }
}
