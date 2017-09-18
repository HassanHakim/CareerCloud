using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private CareerCloudContext _context;
        public EFGenericRepository(bool createProxy = true)
        {
            _context = new CareerCloudContext(createProxy);
        }
        public void Add(params T[] items)
        {
            foreach (var item in items)
            {              
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }
            return dbQuery.ToList();
        }

        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }
            return dbQuery.AsNoTracking().Where(where).ToList<T>();
        }

        public T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }
            return dbQuery.AsNoTracking().FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
            
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Update original values from the database 
                var entry = ex.Entries.Single();
                entry.OriginalValues.SetValues(entry.GetDatabaseValues());
            }
        }
    }
}
