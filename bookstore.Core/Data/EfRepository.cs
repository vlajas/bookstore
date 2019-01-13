using System;
using System.Collections.Generic;
using System.Linq;
using bookstore.Shared;
using bookstore.Shared.Entities;

namespace bookstore.Core.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BookstoreDbContext _context;

        public EfRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
            TEntity entity = _context.Set<TEntity>().Find(id);

            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                _context.Add(entity);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _context.Update(entity);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Remove(entity);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
