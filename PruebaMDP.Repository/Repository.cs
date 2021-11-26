using PruebaMDP.Abstraction;
using System;
using System.Collections.Generic;

namespace PruebaMDP.Repository
{
    public interface IRepository<T> : ICrud<T>
    { 

    }

    public class Repository<T> : IRepository<T> where T: IEntity 
    {
        IDbContext<T> _contexto;
        public Repository(IDbContext<T> contexto)
        {
            _contexto = contexto;
        }

        public void Delete(int id)
        {
            _contexto.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _contexto.GetAll();
        }

        public T GetById(int id)
        {
            return _contexto.GetById(id);
        }

        public T Save(T entity)
        {
            return _contexto.Save(entity);
        }
    }
}
