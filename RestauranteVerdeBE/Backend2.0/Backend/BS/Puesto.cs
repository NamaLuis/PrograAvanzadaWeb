using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Puesto : ICRUD<data.Puesto>
    {
        private restauranteVerdeContext context;
        public Puesto(restauranteVerdeContext _context)
        {
            context = _context;
        }

        public void Delete(data.Puesto t)
        {
            new DAL.Puesto(context).Delete(t);
        }

        public IEnumerable<data.Puesto> GetAll()
        {
            return new DAL.Puesto(context).GetAll();
        }

        public Task<IEnumerable<data.Puesto>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Puesto GetOneByID(int id)
        {
            return new DAL.Puesto(context).GetOneByID(id);
        }

        public Task<data.Puesto> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Puesto t)
        {
            new DAL.Puesto(context).Insert(t);
        }

        public void Update(data.Puesto t)
        {
            new DAL.Puesto(context).Update(t);
        }
    }
}
