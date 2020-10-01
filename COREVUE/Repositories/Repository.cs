using COREVUE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace COREVUE.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DBContext database;
        public DbSet<T> Table { get; set; }

        public Repository(DBContext database)
        {
            this.database = database;
            Table = database.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return Table;
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return Table.FirstOrDefault(expression);
        }
        public T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] expressions)
        {
            var query = Table.Where(expression);
            return expressions.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault();
        }


        public void Create(T entity)
        {
            Table.Add(entity);
        }
        public void Delete(T entity)
        {
            Table.Remove(entity);
        }
        public void Update(T entity)
        {
            Table.Update(entity);
        }
        public bool Save()
        {
            try
            {
                database.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException e)
            {
                return false;
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }
        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }
    }
}
