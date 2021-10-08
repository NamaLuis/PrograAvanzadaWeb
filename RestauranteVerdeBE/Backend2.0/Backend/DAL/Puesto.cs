using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Puesto : ICRUD<data.Puesto>
    {
        private Repository<data.Puesto> _repo = null;

        public Puesto(restauranteVerdeContext solutionDbContext)
        {
            _repo = new Repository<data.Puesto>(solutionDbContext);
        }
        public void Delete(data.Puesto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Puesto> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Puesto>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Puesto GetOneByID(int id)
        {
            return _repo.GetOneById(id);

        }

        public Task<data.Puesto> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Puesto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Puesto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
