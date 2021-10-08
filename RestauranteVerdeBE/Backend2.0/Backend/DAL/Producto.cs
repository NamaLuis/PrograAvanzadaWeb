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
    public class Producto : ICRUD<data.Producto>
    {
        private Repository<data.Producto> _repo = null;

        public Producto(restauranteVerdeContext solutionDbContext)
        {
            _repo = new Repository<data.Producto>(solutionDbContext);
        }

        public void Delete(data.Producto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Producto>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Producto GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Producto> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Producto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Producto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
