using Microsoft.EntityFrameworkCore;
using PruebaMDP.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaMDP.DataAccess
{
    public class DBContext<T> : IDbContext<T> where T : class,IEntity
    {
        DbSet<T> _datos;
        ApiDbContext _contexto;

        public DBContext(ApiDbContext contexto)
        {
            _contexto = contexto;
            _datos = contexto.Set<T>();
        }

        public void Delete(int id)
        {

        }

        public IList<T> GetAll()
        {
            return _datos.ToList();
        }

        public T GetById(int id)
        {
            return _datos.Where(i => i.Id.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            if (_datos.Where(i => i.Id.Equals(entity.Id)).FirstOrDefault() != null)
            {
                _datos.Update(entity);
            }
            else
            {
                _datos.Add(entity);
            }
            _contexto.SaveChanges();
            return entity;
        }
    }
}
