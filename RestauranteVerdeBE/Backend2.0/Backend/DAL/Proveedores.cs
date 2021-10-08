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
    public class Proveedores : ICRUD<data.Proveedores>
    {
        private Repository<data.Proveedores> _repo = null;

        public Proveedores(restauranteVerdeContext solutionDbContext)
        {
            _repo = new Repository<data.Proveedores>(solutionDbContext);
        }

        public void Delete(data.Proveedores t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Proveedores> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Proveedores>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Proveedores GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Proveedores> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Proveedores t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Proveedores t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
