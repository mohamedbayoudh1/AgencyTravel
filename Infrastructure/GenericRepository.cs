using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private  DbContext context;
        private  DbSet<T> dbSet;
       
        public GenericRepository(DbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<T,bool>> where)
        {
            dbSet.RemoveRange(dbSet.Where(where));
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return
           dbSet.Where(where).FirstOrDefault();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }
        public T GetById(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            if (where != null)
            return  dbSet.Where(where).AsEnumerable();
            else
            return dbSet.AsEnumerable();
        }
        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
